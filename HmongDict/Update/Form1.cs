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
using UILanguage;
using Downloader;

namespace Update
{
    public partial class Form1 : Form
    {
        string m_strXmlFile = "UpdateInfo.xml";
        string m_strMainApp = "HmongDict.exe";

        bool m_bAutoUpdate = false;

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

            if (m_bAutoUpdate)
            {
                buttonUpdate_Click(null, null);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.buttonUpdate.Enabled = false;
            MessageBox.Show("autoupdate");
        }

        private void buttonPauseUpdate_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
