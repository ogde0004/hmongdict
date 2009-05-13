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
        long m_nAllFilesLength = 0;        //所有文件总长度
        long m_nAllBytesReadCount = 0;     //所有文件已经读取字节数

        object m_objDownloadRate = (long)0;   //object类型可多线程互斥访问
        int m_nCurrentTaskIndex = -1;
        bool m_bGetAllHttpFilesLengthSuccess = false;
        
        List<DownloadTask> m_DownloadList = new List<DownloadTask>();

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

        public Downloader()
        {
        }

        public void AddTask(string strHttpFileUrl)
        {
            AddTask(strHttpFileUrl, "");
        }
        public void AddTask(string strHttpFileUrl, string strSavePath)
        {
            string[] strSplit = strHttpFileUrl.Split('/');
            string strFileName = strSplit[strSplit.Length - 1];

            AddTask(strHttpFileUrl, strSavePath, strFileName);
        }
        public void AddTask(string strHttpFileUrl, string strSavePath, string strSaveAsFileName)
        {
            DownloadTask task = new DownloadTask();
            task.HttpFileUrl = strHttpFileUrl;
            task.SaveAsFile = strSavePath + strSaveAsFileName;

            AddTask(task);
        }

        public int Count
        {
            get
            {
                return m_DownloadList.Count;
            }
        }

        public string CurrentFileName
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return "";
                    //throw new Exception("Not Init!");
                }

                return m_DownloadList[m_nCurrentTaskIndex].SaveAsFile;
            }
        }
        public long CurrentFileLength
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return 0;
                    //throw new Exception("Not Init!");
                }

                return m_DownloadList[m_nCurrentTaskIndex].FileLength;
            }
        }
        public long CurrentReadBytesCount
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return 0;
                    //throw new Exception("Not Init!");
                }

                return m_DownloadList[m_nCurrentTaskIndex].BytesReadCount;
            }
        }
        public long AllFilesLength
        {
            get
            {
                return m_nAllFilesLength;
            }
        }
        public long AllReadBytesCount
        {
            get
            {
                return m_nAllBytesReadCount;
            }
        }
        public bool Finished
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return false;
                    //throw new Exception("Not Init!");
                }

                return m_bDownloadFinished;
            }
        }
        public bool Success
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return false;
                    //throw new Exception("Not Init!");
                }

                return (m_bDownloadFinished && (m_DownloadList[m_DownloadList.Count - 1].Success));
            }
        }

        public int CurrentDownloadFilePercent
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return 0;
                    //throw new Exception("Not Init!");
                }

                if (m_DownloadList[m_nCurrentTaskIndex].FileLength <= 0)
                    return 0;

                return (int)(m_DownloadList[m_nCurrentTaskIndex].BytesReadCount * 100 / m_DownloadList[m_nCurrentTaskIndex].FileLength);
            }
        }

        public int AllDownloadFilesPercent
        {
            get
            {
                if (m_bDownloadFinished)
                    return 100;

                if (m_bGetAllHttpFilesLengthSuccess)
                    return (int)(m_nAllBytesReadCount * 100 / m_nAllFilesLength);

                return m_nCurrentTaskIndex * 100 / m_DownloadList.Count;
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

                return GetFormatFileLen(nRate) + "/S";
            }
        }
        public string FormatCurrentFileReadBytesCount
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return "";
                    //throw new Exception("Not Init!");
                }

                return GetFormatFileLen(m_DownloadList[m_nCurrentTaskIndex].BytesReadCount);
            }
        }
        public string FormatCurrentFileLength
        {
            get
            {
                if ((m_nCurrentTaskIndex < 0)
                    || (m_nCurrentTaskIndex >= m_DownloadList.Count))
                {
                    return "";
                    //throw new Exception("Not Init!");
                }

                return GetFormatFileLen(m_DownloadList[m_nCurrentTaskIndex].FileLength);
            }
        }
        public string FormatAllFilesLength
        {
            get
            {
                return GetFormatFileLen(m_nAllFilesLength);
            }
        }
        public string FormatAllReadBytesCount
        {
            get
            {
                return GetFormatFileLen(m_nAllBytesReadCount);
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
                m_bGetAllHttpFilesLengthSuccess = false;
                
                Thread threadDown = new Thread(new ThreadStart(Download));
                threadDown.Start();
                
                Thread threadGetLens = new Thread(new ThreadStart(GetAllHttpFilesLength));
                threadGetLens.Start();
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
            m_nCurrentTaskIndex = -1;
            bool bStopDownload = false;

            while (true) //下载失败，循环继续下（第二次下载是从断点处继续下）
            {
                if (bStopDownload)
                    break;

                if (m_nCurrentTaskIndex < (m_DownloadList.Count - 1))
                    m_nCurrentTaskIndex += 1;
                else
                    break;

                switch(m_Action)
                {
                    case DownloaderAction.None:       //无动作
                    case DownloaderAction.Run:        //开始/继续下载
                        DownloadFile();
                        break;

                    case DownloaderAction.Suspend:    //暂停下载
                        lock (m_objDownloadRate)
                        {
                            m_objDownloadRate = (long)0;
                        }
                        Thread.Sleep(500);
                        break;

                    case DownloaderAction.Stop:       //停止下载
                        bStopDownload = true;
                        break;
                }
            }

            m_bDownloadFinished = true;
        }
        private bool DownloadFile()
        {
            FileStream fileStream = File.OpenWrite(m_DownloadList[m_nCurrentTaskIndex].SaveAsFile);
            if (fileStream.CanSeek)
            {
                fileStream.Seek(0, SeekOrigin.End);
            }

            if (m_DownloadList[m_nCurrentTaskIndex].FileLength <= 0)
            {
                m_DownloadList[m_nCurrentTaskIndex].FileLength = GetHttpFileLength(m_DownloadList[m_nCurrentTaskIndex].HttpFileUrl);
            }

            if (m_DownloadList[m_nCurrentTaskIndex].FileLength == fileStream.Length)
            {
                m_DownloadList[m_nCurrentTaskIndex].BytesReadCount = fileStream.Length;
                m_nAllBytesReadCount += fileStream.Length;
                return true;
            }

            if (m_DownloadList[m_nCurrentTaskIndex].FileLength < fileStream.Length)
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                m_DownloadList[m_nCurrentTaskIndex].BytesReadCount = 0;
            }
            else
            {
                m_DownloadList[m_nCurrentTaskIndex].BytesReadCount = fileStream.Length;
                m_nAllBytesReadCount += fileStream.Length;
            }

            int nErrorTimesCount = 0; //服务器拒绝或者文件不存在错误次数
            bool bExitDownloadThisFile = false;
            while (!bExitDownloadThisFile)
            {
                while (m_Action == DownloaderAction.Suspend)    //暂停下载
                {
                    lock (m_objDownloadRate)
                    {
                        m_objDownloadRate = (long)0;
                    }

                    Thread.Sleep(500);
                }

                if ((m_Action == DownloaderAction.Stop)          //停止下载
                    || (nErrorTimesCount > 25))   //或者 错误次数 > 25
                {
                    bExitDownloadThisFile = false;
                    break;
                }

                HttpWebResponse response = null;
                Stream stream = null;

                try
                {
                    HttpWebRequest request = (HttpWebRequest)(HttpWebRequest.Create(new Uri(m_DownloadList[m_nCurrentTaskIndex].HttpFileUrl)));
                    request.Timeout = 10000;
                    request.Accept = @"*/*";
                    request.Referer = GetHttpReferUrl(request.RequestUri.AbsolutePath);
                    request.UserAgent = "";
                    request.AllowAutoRedirect = true;
                    request.AddRange((int)(m_DownloadList[m_nCurrentTaskIndex].BytesReadCount));

                    response = (HttpWebResponse)(request.GetResponse());
                    if (!((response.StatusCode == HttpStatusCode.OK) || (response.StatusCode == HttpStatusCode.PartialContent)))
                    {
                        throw new Exception("HttpStatusCode: " + response.StatusCode.ToString());
                    }

                    m_DownloadList[m_nCurrentTaskIndex].FileLength = m_DownloadList[m_nCurrentTaskIndex].BytesReadCount + response.ContentLength;
                    stream = response.GetResponseStream();

                    Byte[] btArrBuffer = new Byte[10240];
                    int nCurReadBytesCnt = 0;
                    long nReadBytesCnt = 0;
                    DateTime nPrevTime = DateTime.Now;
                    TimeSpan timeSpan;

                    while (true)
                    {
                        if (m_DownloadList[m_nCurrentTaskIndex].BytesReadCount >= m_DownloadList[m_nCurrentTaskIndex].FileLength)
                            break;

                        if ((m_Action == DownloaderAction.Suspend)      //暂停下载
                            || (m_Action == DownloaderAction.Stop))     //或者 停止下载
                            break;

                        nCurReadBytesCnt = stream.Read(btArrBuffer, 0, btArrBuffer.Length);
                        if (nCurReadBytesCnt <= 0)
                            break;

                        fileStream.Write(btArrBuffer, 0, nCurReadBytesCnt);
                        m_DownloadList[m_nCurrentTaskIndex].BytesReadCount += nCurReadBytesCnt;
                        nReadBytesCnt += nCurReadBytesCnt;
                        m_nAllBytesReadCount += nCurReadBytesCnt;
                        nErrorTimesCount = 0;

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
                    stream = null;

                    response.Close();
                    response = null;
                    
                    if ((m_Action != DownloaderAction.Suspend)
                         && (m_Action != DownloaderAction.Stop))
                        bExitDownloadThisFile = true;
                }
                catch   //异常断开连接，等待重新连接
                {
                    lock (m_objDownloadRate)
                    {
                        m_objDownloadRate = (long)0;
                    }

                    try
                    {
                        if (null != stream)
                        {
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                    catch { }
                    
                    try
                    {
                        if (null != response)
                        {
                            response.Close();
                            response = null;
                        }
                    }
                    catch { }

                    nErrorTimesCount += 1;
                    Thread.Sleep(5000); //5秒后重试
                }
            }

            fileStream.Close();
            fileStream.Dispose();
            fileStream = null;

            return m_DownloadList[m_nCurrentTaskIndex].Success;
        }

        private long GetHttpFileLength(string strHttpFileUrl)
        {
            long nLength;

            try
            {
                HttpWebRequest request = (HttpWebRequest)(HttpWebRequest.Create(new Uri(strHttpFileUrl)));
                request.Timeout = 5000;
                request.Accept = @"*/*";
                request.Referer = "";
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
        private void GetAllHttpFilesLength()
        {
            bool bGetAllHttpFilesLengthSuccess = true;
            long HttpFileLength;

            foreach (DownloadTask task in m_DownloadList)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)(HttpWebRequest.Create(new Uri(task.HttpFileUrl)));
                    request.Timeout = 5000;
                    request.Accept = @"*/*";
                    request.Referer = GetHttpReferUrl(request.RequestUri.AbsolutePath);
                    request.UserAgent = "";
                    request.AllowAutoRedirect = true;

                    HttpWebResponse response = (HttpWebResponse)(request.GetResponse());
                    HttpFileLength = response.ContentLength;

                    if (HttpFileLength > 0)
                    {
                        m_nAllFilesLength += HttpFileLength;
                        task.FileLength = HttpFileLength;
                    }
                    else
                    {
                        bGetAllHttpFilesLengthSuccess = false;
                    }

                    response.Close();
                }
                catch
                {
                    bGetAllHttpFilesLengthSuccess = false;
                }
            }

            m_bGetAllHttpFilesLengthSuccess = bGetAllHttpFilesLengthSuccess;
        }
        private string GetHttpReferUrl(string strHttpFileUrl)
        {
            string strReferUrl = strHttpFileUrl;

            int nPos = strHttpFileUrl.LastIndexOf('/');
            if (nPos != -1)
            {
                strReferUrl = strHttpFileUrl.Substring(0, nPos + 1);
            }

            return strReferUrl;
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
        private void AddTask(DownloadTask task)
        {
            this.m_DownloadList.Add(task);
        }
    }
}
