using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Downloader
{
    class DownloadTask
    {
        string m_HttpFileUrl;
        string m_SaveAsFile;
        object m_objFileLength = (long)0;             //当前文件总长度
        object m_objBytesReadCount = (long)0;         //当前文件已经读取字节数
        bool m_bSuccess;

        public long BytesReadCount
        {
            get
            {
                long cnt;

                lock(m_objBytesReadCount)
                {
                    cnt = (long)m_objBytesReadCount;
                }

                return cnt;
            }
            set
            {
                lock (m_objBytesReadCount)
                {
                    m_objBytesReadCount = value;
                }
            }
        }
        public long FileLength
        {
            get
            {
                long cnt;

                lock (m_objFileLength)
                {
                    cnt = (long)m_objFileLength;
                }

                return cnt;
            }
            set
            {
                lock (m_objFileLength)
                {
                    m_objFileLength = value;
                }
            }
        }
        public bool Success
        {
            get
            {
                return m_bSuccess;
            }

            set
            {
                m_bSuccess = value;
            }
        }
        /// <summary>
        /// Get or Set .......
        /// </summary>
        public string HttpFileUrl
        {
            get
            {
                return m_HttpFileUrl;
            }

            set
            {
                m_HttpFileUrl = value;
            }
        }

        /// <summary>
        /// Get or Set .......
        /// </summary>
        public string SaveAsFile
        {
            get
            {
                return m_SaveAsFile;
            }

            set
            {
                m_SaveAsFile = value;
            }
        }
    }
}
