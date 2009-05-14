using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HmongDict
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("这里是Main() " + Environment.CommandLine);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
