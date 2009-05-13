using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using UILanguage;
using Downloader;

namespace Update
{
    public partial class Form1 : Form
    {
        string m_strXmlFile = "UpdateInfo.xml";
        string m_strMainApp = "HmongDict.exe";

        bool m_bAutoUpdate = false;

        Downloader.Downloader m_Downloader = new Downloader.Downloader();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] cmds = Environment.CommandLine.Replace("/", "//").Split(new string[]{" /"}, StringSplitOptions.RemoveEmptyEntries);
            
            for(int i=1; i<cmds.Length; i++)
            {
                if(cmds[i].IndexOf(':') == -1)
                    continue;

                string[] action = cmds[i].Split(new char[]{':'}, StringSplitOptions.RemoveEmptyEntries);
                if(action.Length < 2)
                    continue;

                switch (action[0])
                {
                    case "/UIL":    //GUI 语言
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(action[1]);
                        UILanguage.UILanguage.ApplyResource(this);
                        break;

                    case "/UpdateInfoXmlFile":
                        m_strXmlFile = action[1];
                        break;

                    case "/GuiVisible":
                        /*if (action[1].ToLower() == "false")
                        {
                            this.Opacity = 0.0;
                            this.ShowInTaskbar = false;
                            this.Visible = false;
                        }*/
                        break;

                    case "/MainApp":
                        m_strMainApp = action[1];
                        break;

                    case "/AutoUpdate":
                        m_bAutoUpdate = (action[1].ToLower() == "true");
                        break;
                }
            }

            InitUpdateFilesList();

            if (m_bAutoUpdate)
            {
                buttonUpdate_Click(null, null);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.buttonUpdate.Enabled = false;
            
            m_Downloader.Start();
            
            this.buttonPauseUpdate.Enabled = true;
        }

        private void buttonPauseUpdate_Click(object sender, EventArgs e)
        {
            this.buttonPauseUpdate.Enabled = false;

            m_Downloader.Suspend();

            this.buttonUpdate.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_Downloader.Stop();
            this.Close();
        }

        private void InitUpdateFilesList()
        {
            try
            {
                if (!File.Exists(Application.StartupPath + @"\" + m_strXmlFile))
                    return;

                SoftUpdateInfo sui = new SoftUpdateInfo();
                sui.LoadFile(Application.StartupPath + @"\" + m_strXmlFile);

                bool bNeedUpdate = false;

                for (int i = 0; i < sui.FileCount; i++)
                {
                    string strLocalFile = sui[i].Dir + sui[i].FileName + sui[i].ExtName;
                    if ( (!File.Exists(strLocalFile))
                        || (GetMD5HashFromFile(strLocalFile) != sui[i].MD5) )
                    {
                        m_Downloader.AddTask(sui[i].GetUrl(0), strLocalFile + ".Up");
                        break;
                    }
                }
            }
            catch { }
        }

        public string GetMD5HashFromFile(string fileName)
        {
            FileStream fileStream = File.OpenRead(fileName);
            string md5String = GetMD5HashFromStream(fileStream);
            fileStream.Close();
            fileStream.Dispose();

            return md5String;
        }

        public string GetMD5HashFromStream(Stream stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(stream);

            string strRet = "";
            foreach (byte btVal in retVal)
            {
                strRet += btVal.ToString("X2");
            }

            return strRet;
        }
    }
}
