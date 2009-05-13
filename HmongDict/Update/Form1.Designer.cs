namespace Update
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.progressBarCurrentFile = new System.Windows.Forms.ProgressBar();
            this.labelCurrentFileAndDownRate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.webBrowserNewVersionInfo = new System.Windows.Forms.WebBrowser();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonPauseUpdate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // progressBarTotal
            // 
            resources.ApplyResources(this.progressBarTotal, "progressBarTotal");
            this.progressBarTotal.Name = "progressBarTotal";
            // 
            // progressBarCurrentFile
            // 
            resources.ApplyResources(this.progressBarCurrentFile, "progressBarCurrentFile");
            this.progressBarCurrentFile.Name = "progressBarCurrentFile";
            // 
            // labelCurrentFileAndDownRate
            // 
            resources.ApplyResources(this.labelCurrentFileAndDownRate, "labelCurrentFileAndDownRate");
            this.labelCurrentFileAndDownRate.Name = "labelCurrentFileAndDownRate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // webBrowserNewVersionInfo
            // 
            resources.ApplyResources(this.webBrowserNewVersionInfo, "webBrowserNewVersionInfo");
            this.webBrowserNewVersionInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserNewVersionInfo.Name = "webBrowserNewVersionInfo";
            this.webBrowserNewVersionInfo.Url = new System.Uri("http://www.hmongsoft.com/?Soft=HmongDict&Action=GetNewVersionInfo", System.UriKind.Absolute);
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonPauseUpdate
            // 
            resources.ApplyResources(this.buttonPauseUpdate, "buttonPauseUpdate");
            this.buttonPauseUpdate.Name = "buttonPauseUpdate";
            this.buttonPauseUpdate.UseVisualStyleBackColor = true;
            this.buttonPauseUpdate.Click += new System.EventHandler(this.buttonPauseUpdate_Click);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 750;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPauseUpdate);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.progressBarCurrentFile);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.webBrowserNewVersionInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentFileAndDownRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.ProgressBar progressBarCurrentFile;
        private System.Windows.Forms.Label labelCurrentFileAndDownRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser webBrowserNewVersionInfo;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonPauseUpdate;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

