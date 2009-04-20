using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace Downloader
{
    public class Downloader
    {
        long m_nFileLength = 0;
        long m_nBytesReadCount = 0;
        object m_objDownloadRate = (long)0;   //object类型可多线程互斥访问

        string m_strHttpFileUrl = null;
        string m_strReferUrl = null;
        string m_strSaveAsFile = null;
        FileStream m_FileStream = null;

        bool m_bDownloadFinished = false;    //下载任务成功完成

        public enum DownloaderStatus
        {
            Idle,
            Suspended,
            Running,
            Stoped
        }
        DownloaderStatus m_Status = DownloaderStatus.Idle;

        enum DownloaderAction
        {
            None,
            Suspend,
            Run,
            Stop
        }
        DownloaderAction m_Action = DownloaderAction.None;

        public Downloader(string strHttpFileUrl)
        {
            m_strHttpFileUrl = strHttpFileUrl;
            m_strSaveAsFile = "File.tmp";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strHttpFileUrl">远程web网站文件地址</param>
        /// <param name="strSaveAsFile">保存为本地文件路径及名称</param>
        public Downloader(string strHttpFileUrl, string strSaveAsFile)
        {
            m_strHttpFileUrl = strHttpFileUrl;
            m_strSaveAsFile = strSaveAsFile;
        }

        public long FileLength
        {
            get
            {
                return m_nFileLength;
            }
        }
        public long CurrentReadBytesCount
        {
            get
            {
                return m_nBytesReadCount;
            }
        }
        public bool Finished
        {
            get
            {
                return m_bDownloadFinished;
            }
        }
        public bool Success
        {
            get
            {
                return (m_bDownloadFinished && (m_nBytesReadCount > 0));
            }
        }
        public int CurrentPercent
        {
            get
            {
                if (m_nFileLength <= 0)
                    return 0;

                return (int)(m_nBytesReadCount * 100 / m_nFileLength);
            }
        }
        public long Rate
        {
            get
            {
                long nRate;

                lock (m_objDownloadRate)
                {
                    nRate = (long)m_objDownloadRate;
                }

                return nRate;
            }
        }
        public string FormatRate
        {
            get
            {
                long nRate;

                lock (m_objDownloadRate)
                {
                    nRate = (long)m_objDownloadRate;
                }

                return GetFormatFileLen(nRate);
            }
        }
        public string FormatCurrentReadBytesCount
        {
            get
            {
                return GetFormatFileLen(m_nBytesReadCount);
            }
        }
        public string FormatFileLength
        {
            get
            {
                return GetFormatFileLen(m_nFileLength);
            }
        }
        public DownloaderStatus Status
        {
            get
            {
                return m_Status;
            }
        }

        public void Start()
        {
            m_Status = DownloaderStatus.Running;

            if (m_Action != DownloaderAction.None)
            {
                m_Action = DownloaderAction.Run;
            }
            else
            {
                m_nFileLength = GetHttpFileLength();
                m_strReferUrl = m_strHttpFileUrl.Substring(0, m_strHttpFileUrl.LastIndexOf('/'));

                if (m_nFileLength > 0)
                {
                    Thread thread = new Thread(new ThreadStart(Download));
                    thread.Start();
                }
            }
        }
        public void Suspend()
        {
            m_Action = DownloaderAction.Suspend;
            m_Status = DownloaderStatus.Suspended;
        }
        public void Stop()
        {
            m_Action = DownloaderAction.Stop;
            m_Status = DownloaderStatus.Stoped;
        }

        private void Download()
        {
            m_FileStream = File.Create(m_strSaveAsFile);
            bool bStatus = true;

            while (bStatus) //下载失败，循环继续下（第二次下载是从断点处继续下）
            {
                if(m_nBytesReadCount >= m_nFileLength)
                {
                    break;
                }

                switch(m_Action)
                {
                    case DownloaderAction.None:       //无动作
                    case DownloaderAction.Run:        //开始/继续下载
                        {
                            if (!DownloadFile())    //下载失败(可能是超时或者服务器拒绝。。。)
                            {
                                lock (m_objDownloadRate)
                                {
                                    m_objDownloadRate = (long)0;
                                }
                                
                                if(m_Action == DownloaderAction.Run)
                                    Thread.Sleep(5000); //5秒后重试
                            }
                        }
                        break;

                    case DownloaderAction.Suspend:    //暂停下载
                        lock (m_objDownloadRate)
                        {
                            m_objDownloadRate = (long)0;
                        }
                        Thread.Sleep(500);
                        break;

                    case DownloaderAction.Stop:       //停止下载
                        bStatus = false;
                        break;
                }
            }

            m_FileStream.Close();
            m_FileStream.Dispose();
            m_FileStream = null;

            m_bDownloadFinished = true;
        }
        private bool DownloadFile()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)(HttpWebRequest.Create(new Uri(m_strHttpFileUrl)));
                request.Timeout = 5000;
                request.Accept = @"*/*";
                request.Referer = m_strReferUrl;
                request.UserAgent = "";
                request.AllowAutoRedirect = true;
                request.AddRange((int)m_nBytesReadCount);

                HttpWebResponse response = (HttpWebResponse)(request.GetResponse());
                if (!((response.StatusCode == HttpStatusCode.OK) || (response.StatusCode == HttpStatusCode.PartialContent)))
                {
                    throw new Exception("HttpStatusCode: " + response.StatusCode.ToString());
                }

                m_nFileLength = m_nBytesReadCount + response.ContentLength;

                Stream stream = response.GetResponseStream();

                Byte[] btArrBuffer = new Byte[10240];
                int nCurReadBytesCnt = 0;
                long nReadBytesCnt = 0;
                DateTime nPrevTime = DateTime.Now;
                TimeSpan timeSpan;
                
                while (true)
                {
                    if (m_nBytesReadCount >= m_nFileLength)
                        break;

                    if ((m_Action == DownloaderAction.Suspend)
                        || (m_Action == DownloaderAction.Stop))
                        break;

                    nCurReadBytesCnt = stream.Read(btArrBuffer, 0, btArrBuffer.Length);
                    if (nCurReadBytesCnt <= 0)
                        break;

                    m_FileStream.Write(btArrBuffer, 0, nCurReadBytesCnt);
                    m_nBytesReadCount += nCurReadBytesCnt;
                    nReadBytesCnt += nCurReadBytesCnt;

                    timeSpan = DateTime.Now - nPrevTime;
                    if (timeSpan.TotalMilliseconds > 250)
                    {
                        lock (m_objDownloadRate)
                        {
                            m_objDownloadRate = nReadBytesCnt * 1000 / 900;
                        }

                        nReadBytesCnt = 0;
                        nPrevTime = DateTime.Now;
                    }
                }

                stream.Close();
                stream.Dispose();
                response.Close();
            }
            catch
            {
            }

            return (m_nFileLength == m_nBytesReadCount);
        }
        private long GetHttpFileLength()
        {
            long nLength;

            try
            {
                HttpWebRequest request = (HttpWebRequest)(HttpWebRequest.Create(new Uri(m_strHttpFileUrl)));
                request.Timeout = 5000;
                request.Accept = @"*/*";
                request.Referer = m_strReferUrl;
                request.UserAgent = "";
                request.AllowAutoRedirect = true;

                HttpWebResponse response = (HttpWebResponse)(request.GetResponse());
                nLength = response.ContentLength;

                response.Close();
            }
            catch
            {
                nLength = 0;    //-1
            }

            return nLength;
        }
        private string GetFormatFileLen(long nFileLen)
        {
            if (nFileLen < 1000)   //Byte
            {
                return (nFileLen.ToString() + " B");
            }
            else if (nFileLen < (1024 * 1000))  //KB
            {
                return (Math.Round(((double)nFileLen) / 1024, 2).ToString() + " KB");
            }
            else  //MB
            {
                return (Math.Round(((double)nFileLen) / 1024 / 1024, 2).ToString() + " MB");
            }
        }
    }
}
