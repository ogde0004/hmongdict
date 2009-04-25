using System;
using System.Collections.Generic;

namespace HmongDict
{
    class UpdateFileInfo
    {
        string m_strFileName;   //文件名称
        string m_strExtName;    //扩展名称
        long m_nSize;           //文件大小
        string m_strVersion;    //版本
        string m_strDir;        //目录
        string m_strMimeType;   //类型
        string m_strMD5;        //MD5值
        List<string> m_strUrls = new List<string>(); //下载地址

        public string FileName
        {
            get
            {
                return m_strFileName;
            }
            set
            {
                m_strFileName = value;
            }
        }
        public string ExtName
        {
            get
            {
                return m_strExtName;
            }
            set
            {
                m_strExtName = value;
            }
        }
        public long Size
        {
            get
            {
                return m_nSize;
            }
            set
            {
                m_nSize = value;
            }
        }
        public string Version
        {
            get
            {
                return m_strVersion;
            }
            set
            {
                m_strVersion = value;
            }
        }
        public string Dir
        {
            get
            {
                return m_strDir;
            }
            set
            {
                m_strDir = value;
            }
        }
        public string MimeType
        {
            get
            {
                return m_strMimeType;
            }
            set
            {
                m_strMimeType = value;
            }
        }
        public string MD5
        {
            get
            {
                return m_strMD5;
            }
            set
            {
                m_strMD5 = value.ToUpper();
            }
        }
        public int UrlsCount
        {
            get
            {
                return m_strUrls.Count;
            }
        }
        
        public void AddUrl(string strUrl)
        {
            m_strUrls.Add(strUrl);
        }
        public string GetUrl(int index)
        {
            return m_strUrls[index];
        }

        public override string ToString()
        {
            string str;
            str = "File: " + FileName + "\r\n";
            str += "Ext : " + ExtName + "\r\n";
            str += "Size: " + Size.ToString() + "\r\n";
            str += "Ver : " + Version + "\r\n";
            str += "Dir : " + Dir + "\r\n";
            str += "Mime: " + MimeType + "\r\n";
            str += "MD5: " + MD5 + "\r\n";

            foreach (string url in m_strUrls)
            {
                str += "Url : " + url + "\r\n";
            }

            return str;
        }
    }
}
