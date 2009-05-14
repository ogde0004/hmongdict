using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Globalization;
using UILanguage;
using Downloader;
using System.Net;
using System.Security.Cryptography;
using System.Diagnostics;

namespace HmongDict
{
    public partial class Form1 : Form
    {
        Database m_Database = null;
        GetWord getWord = null;
        Thread m_MainThread = null;
        string[] m_strArrSelectedDictionaries = null;
        string[] m_strArrDictionaries = null;

        readonly string m_strDbFile = @".\Dict.db";     //必须带目录 .\
        string m_strDbFileMD5 = null;

        const string m_strMiniHomgPageUrl = @"http://www.hmongsoft.com/?Soft=HmongDict&Action=GetMiniHomePage";
        const string m_strAddNewWordsPageUrl = @"http://www.hmongsoft.com/?Soft=HmongDict&Action=AddNewWords";
        const string m_strAboutPageUrl = @"http://www.hmongsoft.com/?Soft=HmongDict&Action=About";
        const string m_strGetLastVersionPageUrl = @"http://test.hmongsoft.com/Hmong%20Dictionary/AutoUpdate/?Soft=HmongDict&Action=GetUpdateInfo";

        public Form1()
        {
            InitializeComponent();

            m_MainThread = Thread.CurrentThread;
            string strCurrentLanguage = GetCurrentUILanguage();

            this.webBrowserShowResult.Navigate(m_strMiniHomgPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAddNewWords.Navigate(m_strAddNewWordsPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAbout.Navigate(m_strAboutPageUrl + "&Language=" + GetCurrentUILanguage());

            this.chineseToolStripMenuItem.Checked = (strCurrentLanguage == "zh-CN");
            this.englishToolStripMenuItem.Checked = (strCurrentLanguage == "en");
            this.hmongToolStripMenuItem.Checked = (strCurrentLanguage == "Hmong");

            getWord = new GetWord();
            getWord.OnGetWord += new GetWord.GetWordEventHadler(getWord_OnGetWordEvent);
        }

        void getWord_OnGetWordEvent(object sender, GetWordEventArgs e)
        {
            this.comboBoxWord.Text = e.Word;
        }

        private void comboBoxWord_SizeChanged(object sender, EventArgs e)
        {
            if (this.comboBoxWord.Width > 0)
                this.comboBoxWord.DropDownWidth = this.comboBoxWord.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateLocalFiles(true);

            m_strDbFileMD5 = GetMD5HashFromFile(m_strDbFile);
            m_Database = new Database(m_strDbFile);

            GetDictinaries();
            GetSelectedDictinaries();
            CheckNewVersion();
        }

        private void UpdateLocalFiles(bool bAutoRunSelfAfterUpdate)
        {
            if (File.Exists("UpdateDownload.OK"))
            {
                string strUpdateAppPath = Application.StartupPath + @"\Update.exe";

                if (File.Exists(strUpdateAppPath + ".Up"))
                {
                    if (File.Exists(strUpdateAppPath))
                        File.Delete(strUpdateAppPath);

                    File.Move(strUpdateAppPath + ".Up", strUpdateAppPath);
                }

                if (File.Exists(strUpdateAppPath))
                {
                    Process pro = new Process();
                    pro.StartInfo.Arguments = "/RenameUpdateFiles:Ext=Up /OnlyRenameFiles:True /MainApp:" + Application.ProductName + ".exe" + (bAutoRunSelfAfterUpdate ? "/AutoRun:" + Application.ProductName + ".exe" : "");
                    pro.StartInfo.FileName = strUpdateAppPath;
                    pro.Start();
                }

                this.Close();
            }
        }

        private void CheckNewVersion()
        {
            Thread thread = new Thread(new ThreadStart(AutoUpdate));
            thread.Start();
        }

        private void AutoUpdate()
        {
            try
            {
                Thread.Sleep(3000);
                string strUpdateInfoXmlContent = GetUrlContent(m_strGetLastVersionPageUrl);
                if (strUpdateInfoXmlContent.Length == 0)
                    return;

                File.WriteAllText(Application.StartupPath + @"\UpdateInfo.xml", strUpdateInfoXmlContent, Encoding.Default);
                if (!File.Exists(Application.StartupPath + @"\UpdateInfo.xml"))
                    return;

                SoftUpdateInfo sui = new SoftUpdateInfo();
                sui.LoadFile(Application.StartupPath + @"\UpdateInfo.xml");

                bool bNeedUpdate = false;

                for (int i=0; i<sui.FileCount; i++)
                {
                    string strLocalFile = sui[i].Dir.Replace('/', '\\') + sui[i].FileName + sui[i].ExtName;
                    if (File.Exists(strLocalFile))
                    {
                        try
                        {
                            string strMD5 = "";
                            if (strLocalFile == m_strDbFile)
                                strMD5 = m_strDbFileMD5;
                            else
                                strMD5 = GetMD5HashFromFile(Application.StartupPath + @"\" + strLocalFile);

                            if (strMD5 != sui[i].MD5)
                            {
                                bNeedUpdate = true;
                                break;
                            }

                            FileInfo fi = new FileInfo(Application.StartupPath + @"\" + strLocalFile);
                            if (fi.Length != sui[i].Size)
                            {
                                bNeedUpdate = true;
                                break;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        bNeedUpdate = true;
                        break;
                    }
                }

                if (bNeedUpdate)
                {
                    string strUpdateAppPath = Application.StartupPath + @"\Update.exe";
                    if (File.Exists(strUpdateAppPath))
                    {
                        Process pro = new Process();
                        pro.StartInfo.Arguments = "/UIL:" + GetCurrentUILanguage() + " /MainApp:" + Application.ProductName + ".exe" + " /UpdateInfoXmlFile:UpdateInfo.xml /GuiVisible:False /AutoUpdate:True /FileMD5:" + m_strDbFile + "=" + m_strDbFileMD5;
                        pro.StartInfo.FileName = strUpdateAppPath;
                        pro.StartInfo.CreateNoWindow = true;
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.Start();
                    }
                }
            }
            catch{}
        }

        private string GetUrlContent(string strUrl)
        {
            try
            {
                WebRequest req = HttpWebRequest.Create(new Uri(strUrl));
                WebResponse res = req.GetResponse();
                HttpWebResponse hwr = (HttpWebResponse)res;
                
                if (hwr.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("读取网页内容失败");
                }

                StreamReader sr = new StreamReader(res.GetResponseStream());

                string strUrlPageContent = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();
                res.Close();

                return strUrlPageContent;
            }
            catch
            {
                return ""; 
            }
        }

        public string GetMD5HashFromFile(string fileName)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = File.OpenRead(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show("获取文件MD5值失败，文件正在被使用。\n\n: " + e.Message);
                throw new Exception("获取文件MD5值失败，文件正在被使用。\n\n: " + e.Message);
            }

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

        private string GetCurrentUILanguage()
        {
            return UILanguage.UILanguage.GetCurrentUILanguage(m_MainThread);
        }

        private string GetTableFullNameColumnTitle()
        {
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
            if (ci.Name == "zh-CN")
            {
                return "CnName";
            }
            else if (ci.Name == "en")
            {
                return "EnName";
            }
            else
            {
                return "HmnName";
            }
        }

        private void GetDictinaries()
        {
            this.checkedListBoxDictionaryList.Items.Clear();
            string strDictTableNames = "";
            string strDisplayLanguage = GetTableFullNameColumnTitle();

            SQLiteDataReader reader = m_Database.Query("Select * From TableList");
            while (reader.Read())
            {
                this.checkedListBoxDictionaryList.Items.Add(reader[strDisplayLanguage], int.Parse(reader["Selected"].ToString()) == 1);
                strDictTableNames += reader["TableName"] + "|";
            }

            strDictTableNames = strDictTableNames.TrimEnd('|');
            m_strArrDictionaries = strDictTableNames.Split('|');
        }

        private void GetSelectedDictinaries()
        {
             string strSelDicts = "";

            SQLiteDataReader reader = m_Database.Query("Select * From TableList where Selected=1");
            while (reader.Read())
            {
                strSelDicts += reader["TableName"].ToString();
                strSelDicts += "|";
            }

            strSelDicts = strSelDicts.TrimEnd('|');
            m_strArrSelectedDictionaries = strSelDicts.Split('|');
        }

        private void DisplayLikeWords(string[] strArrWords)
        {
            string strResult = "";

            for (int i = 0; i < strArrWords.Length; i++ )
            {
                if (0 == i)
                    strResult += "<b>" + strArrWords[i] + "</b><br />\r\n";
                else
                    strResult += strArrWords[i] + "<br />\r\n";
            }

            this.webBrowserShowResult.DocumentText = strResult;
        }

        private void SearchLikeWord()
        {
            string strResult = "";

            for (int i = 0; i < m_strArrSelectedDictionaries.Length; i++ )
            {
                SQLiteDataReader reader = m_Database.Query("Select * From " + m_strArrSelectedDictionaries[i] + " where Word Like '" + this.comboBoxWord.Text + "%' limit 50");
                
                while (reader.Read())
                    strResult += reader["Word"].ToString() + "|";
            }

            strResult = strResult.TrimEnd('|');

            DisplayLikeWords(strResult.Split('|'));
        }

        private void SearchWord()
        {
            string strResult = "";
            string strCurrentLg = GetTableFullNameColumnTitle();

            for (int i = 0; i < m_strArrSelectedDictionaries.Length; i++)
            {
                SQLiteDataReader reader = m_Database.Query("Select * From " + m_strArrSelectedDictionaries[i] + " where Word='" + this.comboBoxWord.Text + "' limit 50");
                SQLiteDataReader readerTableFullName = m_Database.Query("Select * From TableList where TableName='" + m_strArrSelectedDictionaries[i] + "' limit 1");

                while (reader.Read())
                    strResult += "<font size=5><b>" + reader["Word"].ToString() + "</b><font>&nbsp;&nbsp;<font size=2><i>[" + readerTableFullName[strCurrentLg] + "]</i></font><br />&nbsp;&nbsp;&nbsp;&nbsp;" + reader["Explanation"].ToString() + "<br /><br />\r\n";
            }

            this.webBrowserShowResult.DocumentText = strResult;

            if (strResult.Length > 0)
            {
                this.comboBoxWord.Items.Insert(0, this.comboBoxWord.Text);

                int nCount = this.comboBoxWord.Items.Count;
                int nMaxItemCount = 15;
                int nDeleteItemCount = 0;
                
                if(nCount > nMaxItemCount)
                    nDeleteItemCount = nCount - nMaxItemCount;

                int nDeletedItemCount = 0;
                while(nDeletedItemCount < nDeleteItemCount)
                {
                    this.comboBoxWord.Items.RemoveAt(nCount - 1 - nDeletedItemCount);
                    nDeletedItemCount += 1;
                }
            }
        }

        private void comboBoxWord_TextChanged(object sender, EventArgs e)
        {
            if (this.comboBoxWord.Text.Length > 0)
                SearchLikeWord();
            else
                this.webBrowserShowResult.Navigate(m_strMiniHomgPageUrl + "&Language=" + GetCurrentUILanguage());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (this.comboBoxWord.Text.Length > 0)
                SearchWord();
            else
                this.webBrowserShowResult.DocumentText = "";
        }

        private void comboBoxWord_KeyDown(object sender, KeyEventArgs e)
        {
            if ( (e.KeyCode == Keys.Enter)
                && this.comboBoxWord.Text.Length > 0)
            {
                SearchWord();
            }
        }

        private void GetScreenWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.GetScreenWordToolStripMenuItem.Checked)
                getWord.StartGetWord();
            else
                getWord.StopGetWord();
        }

        private void hmongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //""为Default语言，作为Hmong语言，更多的关于Culture的字符串请查MSDN
            this.hmongToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.Checked = false;
            this.chineseToolStripMenuItem.Checked = false;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
            UILanguage.UILanguage.ApplyResource(this);
            GetDictinaries();
            this.webBrowserShowResult.Navigate(m_strMiniHomgPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAddNewWords.Navigate(m_strAddNewWordsPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAbout.Navigate(m_strAboutPageUrl + "&Language=" + GetCurrentUILanguage());

            this.chineseToolStripMenuItem.Checked = false;
            this.englishToolStripMenuItem.Checked = false;
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zh-CN为中文，更多的关于Culture的字符串请查MSDN
            this.hmongToolStripMenuItem.Checked = false;
            this.englishToolStripMenuItem.Checked = false;
            this.chineseToolStripMenuItem.Checked = true;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            UILanguage.UILanguage.ApplyResource(this);
            GetDictinaries();
            this.webBrowserShowResult.Navigate(m_strMiniHomgPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAddNewWords.Navigate(m_strAddNewWordsPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAbout.Navigate(m_strAboutPageUrl + "&Language=" + GetCurrentUILanguage());

            this.hmongToolStripMenuItem.Checked = false;
            this.englishToolStripMenuItem.Checked = false;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //en为English，更多的关于Culture的字符串请查MSDN
            this.hmongToolStripMenuItem.Checked = false;
            this.englishToolStripMenuItem.Checked = true;
            this.chineseToolStripMenuItem.Checked = false;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            UILanguage.UILanguage.ApplyResource(this);
            GetDictinaries();
            this.webBrowserShowResult.Navigate(m_strMiniHomgPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAddNewWords.Navigate(m_strAddNewWordsPageUrl + "&Language=" + GetCurrentUILanguage());
            this.webBrowserAbout.Navigate(m_strAboutPageUrl + "&Language=" + GetCurrentUILanguage());
            
            this.hmongToolStripMenuItem.Checked = false;
            this.chineseToolStripMenuItem.Checked = false;
        }

        private void checkedListBoxDictionaryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nCount = this.checkedListBoxDictionaryList.Items.Count;
            for (int i = 0; i < nCount; i++ )
            {
                m_Database.Query("Update TableList SET Selected=" + ((this.checkedListBoxDictionaryList.GetItemChecked(i)) ? "1" : "0") + " Where TableName='" + m_strArrDictionaries[i] + "'");
            }

            GetSelectedDictinaries();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateLocalFiles(false);
        }
    }
}
