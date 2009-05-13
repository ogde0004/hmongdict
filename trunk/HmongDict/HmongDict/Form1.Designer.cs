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
            this.comboBoxWord.AccessibleDescription = null;
            this.comboBoxWord.AccessibleName = null;
            resources.ApplyResources(this.comboBoxWord, "comboBoxWord");
            this.comboBoxWord.BackgroundImage = null;
            this.comboBoxWord.DropDownHeight = 400;
            this.comboBoxWord.DropDownWidth = 262;
            this.comboBoxWord.Font = null;
            this.comboBoxWord.FormattingEnabled = true;
            this.comboBoxWord.Name = "comboBoxWord";
            this.comboBoxWord.SizeChanged += new System.EventHandler(this.comboBoxWord_SizeChanged);
            this.comboBoxWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxWord_KeyDown);
            this.comboBoxWord.TextChanged += new System.EventHandler(this.comboBoxWord_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.AccessibleDescription = null;
            this.buttonSearch.AccessibleName = null;
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.BackgroundImage = null;
            this.buttonSearch.Font = null;
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // webBrowserShowResult
            // 
            this.webBrowserShowResult.AccessibleDescription = null;
            this.webBrowserShowResult.AccessibleName = null;
            resources.ApplyResources(this.webBrowserShowResult, "webBrowserShowResult");
            this.webBrowserShowResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserShowResult.Name = "webBrowserShowResult";
            this.webBrowserShowResult.ScriptErrorsSuppressed = true;
            this.webBrowserShowResult.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabControlMain
            // 
            this.tabControlMain.AccessibleDescription = null;
            this.tabControlMain.AccessibleName = null;
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.BackgroundImage = null;
            this.tabControlMain.ContextMenuStrip = this.contextMenuStripMainUI;
            this.tabControlMain.Controls.Add(this.tabPageSearch);
            this.tabControlMain.Controls.Add(this.tabPageOption);
            this.tabControlMain.Controls.Add(this.tabPageAddNewWord);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.Font = null;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // contextMenuStripMainUI
            // 
            this.contextMenuStripMainUI.AccessibleDescription = null;
            this.contextMenuStripMainUI.AccessibleName = null;
            resources.ApplyResources(this.contextMenuStripMainUI, "contextMenuStripMainUI");
            this.contextMenuStripMainUI.BackgroundImage = null;
            this.contextMenuStripMainUI.Font = null;
            this.contextMenuStripMainUI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetScreenWordToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.contextMenuStripMainUI.Name = "contextMenuStripMainUI";
            // 
            // GetScreenWordToolStripMenuItem
            // 
            this.GetScreenWordToolStripMenuItem.AccessibleDescription = null;
            this.GetScreenWordToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.GetScreenWordToolStripMenuItem, "GetScreenWordToolStripMenuItem");
            this.GetScreenWordToolStripMenuItem.BackgroundImage = null;
            this.GetScreenWordToolStripMenuItem.CheckOnClick = true;
            this.GetScreenWordToolStripMenuItem.Name = "GetScreenWordToolStripMenuItem";
            this.GetScreenWordToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.GetScreenWordToolStripMenuItem.Click += new System.EventHandler(this.GetScreenWordToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.AccessibleDescription = null;
            this.languageToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.BackgroundImage = null;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hmongToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // hmongToolStripMenuItem
            // 
            this.hmongToolStripMenuItem.AccessibleDescription = null;
            this.hmongToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.hmongToolStripMenuItem, "hmongToolStripMenuItem");
            this.hmongToolStripMenuItem.BackgroundImage = null;
            this.hmongToolStripMenuItem.Name = "hmongToolStripMenuItem";
            this.hmongToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.hmongToolStripMenuItem.Click += new System.EventHandler(this.hmongToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.AccessibleDescription = null;
            this.chineseToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.BackgroundImage = null;
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.AccessibleDescription = null;
            this.englishToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.BackgroundImage = null;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.AccessibleDescription = null;
            this.tabPageSearch.AccessibleName = null;
            resources.ApplyResources(this.tabPageSearch, "tabPageSearch");
            this.tabPageSearch.BackgroundImage = null;
            this.tabPageSearch.Controls.Add(this.webBrowserShowResult);
            this.tabPageSearch.Controls.Add(this.buttonSearch);
            this.tabPageSearch.Controls.Add(this.comboBoxWord);
            this.tabPageSearch.Font = null;
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageOption
            // 
            this.tabPageOption.AccessibleDescription = null;
            this.tabPageOption.AccessibleName = null;
            resources.ApplyResources(this.tabPageOption, "tabPageOption");
            this.tabPageOption.BackgroundImage = null;
            this.tabPageOption.Controls.Add(this.groupBox1);
            this.tabPageOption.Font = null;
            this.tabPageOption.Name = "tabPageOption";
            this.tabPageOption.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.checkedListBoxDictionaryList);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkedListBoxDictionaryList
            // 
            this.checkedListBoxDictionaryList.AccessibleDescription = null;
            this.checkedListBoxDictionaryList.AccessibleName = null;
            resources.ApplyResources(this.checkedListBoxDictionaryList, "checkedListBoxDictionaryList");
            this.checkedListBoxDictionaryList.BackgroundImage = null;
            this.checkedListBoxDictionaryList.CheckOnClick = true;
            this.checkedListBoxDictionaryList.Font = null;
            this.checkedListBoxDictionaryList.FormattingEnabled = true;
            this.checkedListBoxDictionaryList.Name = "checkedListBoxDictionaryList";
            this.checkedListBoxDictionaryList.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDictionaryList_SelectedIndexChanged);
            // 
            // tabPageAddNewWord
            // 
            this.tabPageAddNewWord.AccessibleDescription = null;
            this.tabPageAddNewWord.AccessibleName = null;
            resources.ApplyResources(this.tabPageAddNewWord, "tabPageAddNewWord");
            this.tabPageAddNewWord.BackgroundImage = null;
            this.tabPageAddNewWord.Controls.Add(this.webBrowserAddNewWords);
            this.tabPageAddNewWord.Font = null;
            this.tabPageAddNewWord.Name = "tabPageAddNewWord";
            this.tabPageAddNewWord.UseVisualStyleBackColor = true;
            // 
            // webBrowserAddNewWords
            // 
            this.webBrowserAddNewWords.AccessibleDescription = null;
            this.webBrowserAddNewWords.AccessibleName = null;
            resources.ApplyResources(this.webBrowserAddNewWords, "webBrowserAddNewWords");
            this.webBrowserAddNewWords.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAddNewWords.Name = "webBrowserAddNewWords";
            this.webBrowserAddNewWords.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.AccessibleDescription = null;
            this.tabPageAbout.AccessibleName = null;
            resources.ApplyResources(this.tabPageAbout, "tabPageAbout");
            this.tabPageAbout.BackgroundImage = null;
            this.tabPageAbout.Controls.Add(this.webBrowserAbout);
            this.tabPageAbout.Font = null;
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // webBrowserAbout
            // 
            this.webBrowserAbout.AccessibleDescription = null;
            this.webBrowserAbout.AccessibleName = null;
            resources.ApplyResources(this.webBrowserAbout, "webBrowserAbout");
            this.webBrowserAbout.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAbout.Name = "webBrowserAbout";
            this.webBrowserAbout.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.ContextMenuStrip = this.contextMenuStripMainUI;
            this.statusStrip1.Font = null;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.AccessibleDescription = null;
            this.toolStripStatusLabelMessage.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabelMessage, "toolStripStatusLabelMessage");
            this.toolStripStatusLabelMessage.BackgroundImage = null;
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            // 
            // Form1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.ContextMenuStrip = this.contextMenuStripMainUI;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Font = null;
            this.Icon = null;
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

