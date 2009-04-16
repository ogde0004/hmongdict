namespace HmongDict
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxWord = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.webBrowserShowResult = new System.Windows.Forms.WebBrowser();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPageOption = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPageAddNewWord = new System.Windows.Forms.TabPage();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.tabPageOption.SuspendLayout();
            this.tabPageAddNewWord.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxWord
            // 
            this.comboBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWord.DropDownHeight = 400;
            this.comboBoxWord.DropDownWidth = 262;
            this.comboBoxWord.FormattingEnabled = true;
            this.comboBoxWord.IntegralHeight = false;
            this.comboBoxWord.Items.AddRange(new object[] {
            "fdsfsaf",
            "f",
            "sf",
            "s",
            "f",
            "ag",
            "as",
            "g",
            "sg",
            "sg",
            "d",
            "g",
            "sfdsf"});
            this.comboBoxWord.Location = new System.Drawing.Point(6, 6);
            this.comboBoxWord.Name = "comboBoxWord";
            this.comboBoxWord.Size = new System.Drawing.Size(263, 20);
            this.comboBoxWord.TabIndex = 0;
            this.comboBoxWord.SizeChanged += new System.EventHandler(this.comboBoxWord_SizeChanged);
            this.comboBoxWord.TextChanged += new System.EventHandler(this.comboBoxWord_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(275, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(79, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // webBrowserShowResult
            // 
            this.webBrowserShowResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserShowResult.Location = new System.Drawing.Point(6, 31);
            this.webBrowserShowResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserShowResult.Name = "webBrowserShowResult";
            this.webBrowserShowResult.ScriptErrorsSuppressed = true;
            this.webBrowserShowResult.Size = new System.Drawing.Size(348, 395);
            this.webBrowserShowResult.TabIndex = 2;
            this.webBrowserShowResult.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlMain.Controls.Add(this.tabPageSearch);
            this.tabControlMain.Controls.Add(this.tabPageOption);
            this.tabControlMain.Controls.Add(this.tabPageAddNewWord);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.ItemSize = new System.Drawing.Size(80, 35);
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(0, 0);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(368, 475);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.webBrowserShowResult);
            this.tabPageSearch.Controls.Add(this.buttonSearch);
            this.tabPageSearch.Controls.Add(this.comboBoxWord);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 39);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(360, 432);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageOption
            // 
            this.tabPageOption.Controls.Add(this.label1);
            this.tabPageOption.Controls.Add(this.button2);
            this.tabPageOption.Controls.Add(this.button1);
            this.tabPageOption.Controls.Add(this.listBox2);
            this.tabPageOption.Controls.Add(this.listBox1);
            this.tabPageOption.Location = new System.Drawing.Point(4, 39);
            this.tabPageOption.Name = "tabPageOption";
            this.tabPageOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOption.Size = new System.Drawing.Size(360, 432);
            this.tabPageOption.TabIndex = 1;
            this.tabPageOption.Text = "Option";
            this.tabPageOption.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(212, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(142, 172);
            this.listBox2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(145, 172);
            this.listBox1.TabIndex = 0;
            // 
            // tabPageAddNewWord
            // 
            this.tabPageAddNewWord.Controls.Add(this.richTextBox1);
            this.tabPageAddNewWord.Location = new System.Drawing.Point(4, 39);
            this.tabPageAddNewWord.Name = "tabPageAddNewWord";
            this.tabPageAddNewWord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddNewWord.Size = new System.Drawing.Size(360, 432);
            this.tabPageAddNewWord.TabIndex = 2;
            this.tabPageAddNewWord.Text = "Add";
            this.tabPageAddNewWord.UseVisualStyleBackColor = true;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 39);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(360, 432);
            this.tabPageAbout.TabIndex = 3;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(379, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            this.toolStripStatusLabelMessage.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabelMessage.Text = "Ready";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(348, 420);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 504);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Hmong Dictionrary";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.tabPageOption.ResumeLayout(false);
            this.tabPageOption.PerformLayout();
            this.tabPageAddNewWord.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWord;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.WebBrowser webBrowserShowResult;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageOption;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPageAddNewWord;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

