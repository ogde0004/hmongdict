using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace Update
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string m_strAutoRunApp = "";
            string[] cmds = Environment.CommandLine.Replace("/", "//").Split(new string[] { " /" }, StringSplitOptions.RemoveEmptyEntries);
            bool bOnlyRenameFiles = false;

            for (int i = 1; i < cmds.Length; i++)
            {
                if (cmds[i].IndexOf(':') == -1)
                    continue;

                string[] action = cmds[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (action.Length < 2)
                    continue;

                switch (action[0])
                {
                    case "/AutoRun":
                        m_strAutoRunApp = action[1];
                        break;

                    case "/RenameFiles":
                        string[] rf = action[1].Split('>');
                        File.Move(rf[0], rf[1]);
                        break;

                    case "/RenameUpdateFiles":
                        if (File.Exists("UpdateDownload.OK"))
                            File.Delete("UpdateDownload.OK");

                        RenameUpdateFiles(Application.StartupPath + @"\");
                        break;

                    case "/OnlyRenameFiles":
                        bOnlyRenameFiles = (action[1].ToLower() == "true");
                        break;
                }
            }

            if (bOnlyRenameFiles)
            {
                if ( (m_strAutoRunApp != "") && File.Exists(m_strAutoRunApp) )
                {
                    Process pro = new Process();
                    pro.StartInfo.Arguments = "";
                    pro.StartInfo.FileName = m_strAutoRunApp;
                    pro.Start();
                }

                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        public static void RenameUpdateFiles(string strDir)
        {
            string[] fs = Directory.GetFiles(strDir);
            foreach (string file in fs)
            {

                FileInfo fi = new FileInfo(file);
                if (fi.Extension.ToLower() == ".up")
                {
                    string strDestFile = file.Remove(file.Length - 3, 3);

                    while (true)
                    {
                        try
                        {
                            if (File.Exists(strDestFile))
                                File.Delete(strDestFile);

                            File.Move(file, strDestFile);

                            break;
                        }
                        catch
                        {
                            Thread.Sleep(500);
                        }
                    }
                }
            }

            string[] ds = Directory.GetDirectories(strDir);
            foreach (string dir in ds)
            {
                RenameUpdateFiles(dir);
            }
        }
    }
}
