using System;
using System.Collections.Generic;
using System.Xml;

namespace HmongDict
{
    class SoftUpdateInfo
    {
        List<UpdateFileInfo> m_nFileList = new List<UpdateFileInfo>();
        string m_strVersion;
        string m_strName;
        string m_strAuthor;
        string m_strMainAppName;

        public string Name
        {
            get
            {
                return m_strName;
            }
        }
        public string Version
        {
            get
            {
                return m_strVersion;
            }
        }
        public string Author
        {
            get
            {
                return m_strAuthor;
            }
        }
        public string MainAppName
        {
            get
            {
                return m_strMainAppName;
            }
        }

        public int FileCount
        {
            get
            {
                return m_nFileList.Count;
            }
        }

        public UpdateFileInfo this[int index]
        {
            get
            {
                return m_nFileList[index];
            }
        }

        public void LoadFile(string strFileName)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(strFileName);

            ParseXml(ref XmlDoc);
        }

        public void LoadXmlContent(string strXmlContent)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(strXmlContent);

            ParseXml(ref XmlDoc);
        }

        private void LoadXml(string strContent)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(strContent);

            ParseXml(ref XmlDoc);
        }

        private void ParseXml(ref XmlDocument XmlDoc)
        {
            XmlNodeList SoftwareNodeList = XmlDoc.SelectNodes("Software");
            if (null == SoftwareNodeList)
                throw new Exception("null");

            m_strName = SoftwareNodeList[0].Attributes["Name"].Value;
            m_strVersion = SoftwareNodeList[0].Attributes["Version"].Value;
            m_strAuthor = SoftwareNodeList[0].Attributes["Author"].Value;
            m_strMainAppName = SoftwareNodeList[0].Attributes["MainAppName"].Value;

            XmlNodeList FileListNodeList = SoftwareNodeList[0].SelectNodes("FileList");
            if (null == FileListNodeList)
                throw new Exception("null");

            foreach (XmlNode FileListNode in FileListNodeList)
            {
                XmlNodeList FileNodeList = FileListNode.SelectNodes("File");
                foreach (XmlNode FileNode in FileNodeList)
                {
                    if (FileNode.HasChildNodes)
                    {
                        UpdateFileInfo CurUpdateFileInfo = new UpdateFileInfo();
                        XmlNode Element = FileNode.FirstChild;
                        do
                        {
                            switch (Element.Name)
                            {
                                case "Name":
                                    CurUpdateFileInfo.FileName = Element.InnerText;
                                    break;

                                case "Ext":
                                    CurUpdateFileInfo.ExtName = Element.InnerText;
                                    break;

                                case "Size":
                                    CurUpdateFileInfo.Size = long.Parse(Element.InnerText);
                                    break;

                                case "Version":
                                    CurUpdateFileInfo.Version = Element.InnerText;
                                    break;

                                case "Dir":
                                    CurUpdateFileInfo.Dir = Element.InnerText;
                                    break;
                                
                                case "MimeType":
                                    CurUpdateFileInfo.MimeType = Element.InnerText;
                                    break;

                                case "MD5":
                                    CurUpdateFileInfo.MD5 = Element.InnerText;
                                    break;

                                case "Urls":
                                    foreach (XmlNode UrlNode in Element.ChildNodes)
                                    {
                                        CurUpdateFileInfo.AddUrl(UrlNode.InnerText);
                                    }
                                    break;

                                default:
                                    break;
                            }
                            
                            Element = Element.NextSibling;
                        }
                        while (null != Element);

                        m_nFileList.Add(CurUpdateFileInfo);
                    }
                }
            }
        }

        public override string ToString()
        {
            string str;
            str = "Name    : " + Name + "\r\n";
            str += "Version : " + Version + "\r\n";
            str += "Author  : " + Author + "\r\n";
            str += "MainApp : " + MainAppName + "\r\n";

            str += "\t";

            foreach (UpdateFileInfo ufi in m_nFileList)
            {
                str += ufi.ToString().Replace("\r\n", "\r\n\t");
            }

            str.TrimEnd('\r', '\n', '\t');
            return str;
        }
    }
}
