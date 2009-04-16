using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace HmongDict
{
    public partial class Form1 : Form
    {
        Database m_Database = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxWord_SizeChanged(object sender, EventArgs e)
        {
            this.comboBoxWord.DropDownWidth = this.comboBoxWord.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_Database = new Database();

            if (File.Exists("English_Hmong.wb"))
            {
                FileInfo fi = new FileInfo("English_Hmong.wb");
                StreamReader sr = new StreamReader("English_Hmong.wb", Encoding.Default);
                Char[] btData = new Char[84];

                int ii = 0;

                while (sr.Read(btData, 0, 84) > 0)
                {
                    if (ii++ > 20)
                        break;

                    for (int i = 0; i < 84;i++ )
                    {
                        if (btData[i] == 0)
                        {
                            btData[i] = ' ';
                        }
                    }

                    string str = new string(btData);
                    str = str.Replace("  ", " ");

                    this.richTextBox1.AppendText( str + "\r\n");
                }

                sr.Close();

                this.webBrowserShowResult.DocumentText += "English_Hmong.wb 文件存在\n" + fi.FullName + "\nSize = " + fi.Length.ToString();
            }
        }

        private void comboBoxWord_TextChanged(object sender, EventArgs e)
        {
            SQLiteDataReader reader = m_Database.Query("Select * From TableList");
            if (reader.HasRows)
            {
                do
                {   
                    reader.Read();
                    this.webBrowserShowResult.DocumentText += reader["ID"].ToString() + reader["CnName"].ToString() + reader["EnName"].ToString() + reader["HmName"].ToString() + reader["TableName"].ToString() + "<br />\r\n"; ;
                }
                while (reader.NextResult()) ;
            }
        }
    }
}
