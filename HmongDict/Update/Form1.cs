using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using UILanguage;
using Downloader;
using HmongDict;

namespace Update
{
    public partial class Form1 : Form
    {
        string m_strXmlFile = "UpdateInfo.xml";
        string m_strMainApp = "HmongDict.exe";

        bool m_bAutoUpdate = false;

        struct SFileMD5
        {
            public string strFileName;
            public string strMD5;
        }

        List<SFileMD5> m_SFileMD5List = new List<SFileMD5>();

        Downloader.Downloader m_Downloader = new Downloader.Downloader();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] cmds = Environment.CommandLine.Replace("/", "//").Split(new string[]{" /"}, StringSplitOptions.RemoveEmptyEntries);
            bool bOnlyRenameFiles = false;

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
                        if (action[1].ToLower() == "false")
                        {
                            this.Opacity = 0.0;
                            this.ShowInTaskbar = false;
                            this.Visible = false;
                        }
                        break;

                    case "/MainApp":
                        m_strMainApp = action[1];
                        break;

                    case "/AutoUpdate":
                        m_bAutoUpdate = (action[1].ToLower() == "true");
                        break;

                    case "/FileMD5":
                        string[] fm = action[1].Split('=');
                        SFileMD5 sf = new SFileMD5();
                        sf.strFileName = fm[0];
                        sf.strMD5 = fm[1];
                        m_SFileMD5List.Add(sf);
                        break;

                    case "/RenameFiles":
                        string[] rf = action[1].Split('>');
                        File.Move(rf[0], rf[1]);
                        break;

                    case "/RenameUpdateFiles":
                        Program.RenameUpdateFiles(Application.StartupPath + @"\");
                        break;

                    case "/OnlyRenameFiles":
                        bOnlyRenameFiles = (action[1].ToLower() == "true");
                        break;
                }
            }

            if (bOnlyRenameFiles)
            {
                Process pro = new Process();
                pro.StartInfo.Arguments = "";
                pro.StartInfo.FileName = m_strMainApp;
                pro.Start();

                this.Close();
            }
            else
            {
                InitUpdateFilesList();

                if (m_bAutoUpdate)
                {
                    buttonUpdate_Click(null, null);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.buttonUpdate.Enabled = false;
            
            m_Downloader.Start();
            timerUpdate.Enabled = true;
            
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
                SoftUpdateInfo sui = new SoftUpdateInfo();

                if (File.Exists(Application.StartupPath + @"\" + m_strXmlFile))
                    sui.LoadFile(Application.StartupPath + @"\" + m_strXmlFile);
                else
                    sui.LoadFile(@"http://test.hmongsoft.com/Hmong%20Dictionary/AutoUpdate/?Action=GetUpdateInfo");

                for (int i = 0; i < sui.FileCount; i++)
                {
                    string strLocalFile = sui[i].Dir.Replace('/', '\\') + sui[i].FileName + sui[i].ExtName;
                    string strLocalFileMD5 = "";

                    if (File.Exists(Application.StartupPath + @"\" + strLocalFile))
                    {
                        try
                        {
                            strLocalFileMD5 = GetMD5HashFromFile(Application.StartupPath + @"\" + strLocalFile);
                        }
                        catch
                        {
                            foreach(SFileMD5 sf in m_SFileMD5List)
                            {
                                if (sf.strFileName == strLocalFile)
                                {
                                    strLocalFileMD5 = sf.strMD5;
                                    break;
                                }
                            }
                        }
                    }

                    if ((!File.Exists(Application.StartupPath + @"\" + strLocalFile))
                        || (strLocalFileMD5 != sui[i].MD5))
                    {
                        m_Downloader.AddTask(sui[i].GetUrl(0), sui[i].Dir.Replace('/', '\\'), sui[i].FileName + sui[i].ExtName + (m_bAutoUpdate ? ".Up" : ""));
                        this.labelCurrentFileAndDownRate.Text = m_Downloader.Count.ToString() + " Files Need Download!";
                        break;
                    }
                }
            }
            catch { }
        }

        public string GetMD5HashFromFile(string fileName)
        {
            FileStream fileStream = null;

            /*try
            {*/
                fileStream = File.OpenRead(fileName);
            /*}
            catch (Exception e)
            {
                MessageBox.Show("获取文件MD5值失败，文件正在被使用。\n\n: " + e.Message);
                throw new Exception("获取文件MD5值失败，文件正在被使用。\n\n: " + e.Message);
            }*/

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

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (m_Downloader.Success)
            {
                this.labelCurrentFileAndDownRate.Text = "All Files Download Completed(100%)";
                this.progressBarCurrentFile.Value = this.progressBarCurrentFile.Maximum;
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;

                this.buttonUpdate.Enabled = false;
                this.buttonPauseUpdate.Enabled = false;

                this.timerUpdate.Enabled = false;

                if (m_bAutoUpdate)
                {
                    this.Close();
                    File.WriteAllText(Application.StartupPath + @"\UpdateDownload.OK", "Update Files Download Completed");
                }
            }
            else
            {
                this.labelCurrentFileAndDownRate.Text = m_Downloader.CurrentFileName + "(" + m_Downloader.FormatRate + "    " + m_Downloader.FormatCurrentFileReadBytesCount + "/" + m_Downloader.FormatCurrentFileLength + ")";
                this.progressBarCurrentFile.Value = this.progressBarCurrentFile.Maximum;
                this.progressBarTotal.Value = this.progressBarTotal.Maximum;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(m_strXmlFile))
                File.Delete(m_strXmlFile);
        }
    }
}
