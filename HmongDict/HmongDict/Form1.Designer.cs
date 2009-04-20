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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxWord = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.webBrowserShowResult = new System.Windows.Forms.WebBrowser();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.contextMenuStripMainUI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GetScreenWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hmongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPageOption = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxDictionaryList = new System.Windows.Forms.CheckedListBox();
            this.tabPageAddNewWord = new System.Windows.Forms.TabPage();
            this.webBrowserAddNewWords = new System.Windows.Forms.WebBrowser();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.webBrowserAbout = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.contextMenuStripMainUI.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.tabPageOption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageAddNewWord.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxWord
            // 
            resources.ApplyResources(this.comboBoxWord, "comboBoxWord");
            this.comboBoxWord.DropDownHeight = 400;
            this.comboBoxWord.DropDownWidth = 262;
            this.comboBoxWord.FormattingEnabled = true;
            this.comboBoxWord.Name = "comboBoxWord";
            this.comboBoxWord.SizeChanged += new System.EventHandler(this.comboBoxWord_SizeChanged);
            this.comboBoxWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxWord_KeyDown);
            this.comboBoxWord.TextChanged += new System.EventHandler(this.comboBoxWord_TextChanged);
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // webBrowserShowResult
            // 
            resources.ApplyResources(this.webBrowserShowResult, "webBrowserShowResult");
            this.webBrowserShowResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserShowResult.Name = "webBrowserShowResult";
            this.webBrowserShowResult.ScriptErrorsSuppressed = true;
            this.webBrowserShowResult.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.ContextMenuStrip = this.contextMenuStripMainUI;
            this.tabControlMain.Controls.Add(this.tabPageSearch);
            this.tabControlMain.Controls.Add(this.tabPageOption);
            this.tabControlMain.Controls.Add(this.tabPageAddNewWord);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // contextMenuStripMainUI
            // 
            this.contextMenuStripMainUI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetScreenWordToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.contextMenuStripMainUI.Name = "contextMenuStripMainUI";
            resources.ApplyResources(this.contextMenuStripMainUI, "contextMenuStripMainUI");
            // 
            // GetScreenWordToolStripMenuItem
            // 
            this.GetScreenWordToolStripMenuItem.CheckOnClick = true;
            this.GetScreenWordToolStripMenuItem.Name = "GetScreenWordToolStripMenuItem";
            resources.ApplyResources(this.GetScreenWordToolStripMenuItem, "GetScreenWordToolStripMenuItem");
            this.GetScreenWordToolStripMenuItem.Click += new System.EventHandler(this.GetScreenWordToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hmongToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // hmongToolStripMenuItem
            // 
            this.hmongToolStripMenuItem.Name = "hmongToolStripMenuItem";
            resources.ApplyResources(this.hmongToolStripMenuItem, "hmongToolStripMenuItem");
            this.hmongToolStripMenuItem.Click += new System.EventHandler(this.hmongToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.webBrowserShowResult);
            this.tabPageSearch.Controls.Add(this.buttonSearch);
            this.tabPageSearch.Controls.Add(this.comboBoxWord);
            resources.ApplyResources(this.tabPageSearch, "tabPageSearch");
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageOption
            // 
            this.tabPageOption.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPageOption, "tabPageOption");
            this.tabPageOption.Name = "tabPageOption";
            this.tabPageOption.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBoxDictionaryList);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkedListBoxDictionaryList
            // 
            this.checkedListBoxDictionaryList.CheckOnClick = true;
            this.checkedListBoxDictionaryList.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxDictionaryList, "checkedListBoxDictionaryList");
            this.checkedListBoxDictionaryList.Name = "checkedListBoxDictionaryList";
            this.checkedListBoxDictionaryList.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDictionaryList_SelectedIndexChanged);
            // 
            // tabPageAddNewWord
            // 
            this.tabPageAddNewWord.Controls.Add(this.webBrowserAddNewWords);
            resources.ApplyResources(this.tabPageAddNewWord, "tabPageAddNewWord");
            this.tabPageAddNewWord.Name = "tabPageAddNewWord";
            this.tabPageAddNewWord.UseVisualStyleBackColor = true;
            // 
            // webBrowserAddNewWords
            // 
            resources.ApplyResources(this.webBrowserAddNewWords, "webBrowserAddNewWords");
            this.webBrowserAddNewWords.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAddNewWords.Name = "webBrowserAddNewWords";
            this.webBrowserAddNewWords.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.webBrowserAbout);
            resources.ApplyResources(this.tabPageAbout, "tabPageAbout");
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // webBrowserAbout
            // 
            resources.ApplyResources(this.webBrowserAbout, "webBrowserAbout");
            this.webBrowserAbout.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAbout.Name = "webBrowserAbout";
            this.webBrowserAbout.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.contextMenuStripMainUI;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            resources.ApplyResources(this.toolStripStatusLabelMessage, "toolStripStatusLabelMessage");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStripMainUI;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.contextMenuStripMainUI.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.tabPageOption.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPageAddNewWord.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMainUI;
        private System.Windows.Forms.ToolStripMenuItem GetScreenWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hmongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBoxDictionaryList;
        private System.Windows.Forms.WebBrowser webBrowserAbout;
        private System.Windows.Forms.WebBrowser webBrowserAddNewWords;
    }
}

