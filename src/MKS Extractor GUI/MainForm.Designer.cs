namespace MKS_Extractor_GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox_toolnix = new System.Windows.Forms.GroupBox();
            this.button_toolnix_browse = new System.Windows.Forms.Button();
            this.textBox_toolnix_path = new System.Windows.Forms.TextBox();
            this.groupBox_mkvlist = new System.Windows.Forms.GroupBox();
            this.listBox_mkvlist = new System.Windows.Forms.ListBox();
            this.groupBox_languages = new System.Windows.Forms.GroupBox();
            this.button_language_add = new System.Windows.Forms.Button();
            this.textBox_language_add = new System.Windows.Forms.TextBox();
            this.listBox_languages = new System.Windows.Forms.ListBox();
            this.button_job = new System.Windows.Forms.Button();
            this.groupBox_job = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_current = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_current = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_extract = new System.Windows.Forms.Timer(this.components);
            this.groupBox_toolnix.SuspendLayout();
            this.groupBox_mkvlist.SuspendLayout();
            this.groupBox_languages.SuspendLayout();
            this.groupBox_job.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_toolnix
            // 
            this.groupBox_toolnix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_toolnix.Controls.Add(this.button_toolnix_browse);
            this.groupBox_toolnix.Controls.Add(this.textBox_toolnix_path);
            this.groupBox_toolnix.Location = new System.Drawing.Point(12, 12);
            this.groupBox_toolnix.Name = "groupBox_toolnix";
            this.groupBox_toolnix.Size = new System.Drawing.Size(510, 52);
            this.groupBox_toolnix.TabIndex = 0;
            this.groupBox_toolnix.TabStop = false;
            this.groupBox_toolnix.Text = "MKVToolNix Directory";
            // 
            // button_toolnix_browse
            // 
            this.button_toolnix_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_toolnix_browse.Location = new System.Drawing.Point(413, 15);
            this.button_toolnix_browse.Name = "button_toolnix_browse";
            this.button_toolnix_browse.Size = new System.Drawing.Size(91, 27);
            this.button_toolnix_browse.TabIndex = 1;
            this.button_toolnix_browse.Text = "Browse";
            this.button_toolnix_browse.UseVisualStyleBackColor = true;
            this.button_toolnix_browse.Click += new System.EventHandler(this.button_toolnix_browse_Click);
            // 
            // textBox_toolnix_path
            // 
            this.textBox_toolnix_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_toolnix_path.Location = new System.Drawing.Point(6, 19);
            this.textBox_toolnix_path.Name = "textBox_toolnix_path";
            this.textBox_toolnix_path.ReadOnly = true;
            this.textBox_toolnix_path.Size = new System.Drawing.Size(401, 20);
            this.textBox_toolnix_path.TabIndex = 0;
            // 
            // groupBox_mkvlist
            // 
            this.groupBox_mkvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_mkvlist.Controls.Add(this.listBox_mkvlist);
            this.groupBox_mkvlist.Location = new System.Drawing.Point(12, 70);
            this.groupBox_mkvlist.Name = "groupBox_mkvlist";
            this.groupBox_mkvlist.Size = new System.Drawing.Size(386, 328);
            this.groupBox_mkvlist.TabIndex = 1;
            this.groupBox_mkvlist.TabStop = false;
            this.groupBox_mkvlist.Text = "MKV Files";
            // 
            // listBox_mkvlist
            // 
            this.listBox_mkvlist.AllowDrop = true;
            this.listBox_mkvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_mkvlist.FormattingEnabled = true;
            this.listBox_mkvlist.HorizontalScrollbar = true;
            this.listBox_mkvlist.Location = new System.Drawing.Point(6, 15);
            this.listBox_mkvlist.Name = "listBox_mkvlist";
            this.listBox_mkvlist.Size = new System.Drawing.Size(374, 303);
            this.listBox_mkvlist.Sorted = true;
            this.listBox_mkvlist.TabIndex = 0;
            this.listBox_mkvlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_mkvlist_MouseClick);
            this.listBox_mkvlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_mkvlist_DragDrop);
            this.listBox_mkvlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_mkvlist_DragEnter);
            // 
            // groupBox_languages
            // 
            this.groupBox_languages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_languages.Controls.Add(this.button_language_add);
            this.groupBox_languages.Controls.Add(this.textBox_language_add);
            this.groupBox_languages.Controls.Add(this.listBox_languages);
            this.groupBox_languages.Location = new System.Drawing.Point(404, 70);
            this.groupBox_languages.Name = "groupBox_languages";
            this.groupBox_languages.Size = new System.Drawing.Size(118, 328);
            this.groupBox_languages.TabIndex = 2;
            this.groupBox_languages.TabStop = false;
            this.groupBox_languages.Text = "Languages";
            // 
            // button_language_add
            // 
            this.button_language_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_language_add.Location = new System.Drawing.Point(6, 295);
            this.button_language_add.Name = "button_language_add";
            this.button_language_add.Size = new System.Drawing.Size(106, 27);
            this.button_language_add.TabIndex = 3;
            this.button_language_add.Text = "Add";
            this.button_language_add.UseVisualStyleBackColor = true;
            this.button_language_add.Click += new System.EventHandler(this.button_language_add_Click);
            // 
            // textBox_language_add
            // 
            this.textBox_language_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_language_add.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_language_add.Location = new System.Drawing.Point(6, 269);
            this.textBox_language_add.Name = "textBox_language_add";
            this.textBox_language_add.Size = new System.Drawing.Size(106, 20);
            this.textBox_language_add.TabIndex = 1;
            this.textBox_language_add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_language_add_KeyDown);
            // 
            // listBox_languages
            // 
            this.listBox_languages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_languages.FormattingEnabled = true;
            this.listBox_languages.Location = new System.Drawing.Point(6, 15);
            this.listBox_languages.Name = "listBox_languages";
            this.listBox_languages.Size = new System.Drawing.Size(106, 251);
            this.listBox_languages.Sorted = true;
            this.listBox_languages.TabIndex = 0;
            this.listBox_languages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_languages_MouseClick);
            // 
            // button_job
            // 
            this.button_job.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_job.Location = new System.Drawing.Point(6, 19);
            this.button_job.Name = "button_job";
            this.button_job.Size = new System.Drawing.Size(498, 45);
            this.button_job.TabIndex = 3;
            this.button_job.Text = "Extract";
            this.button_job.UseVisualStyleBackColor = true;
            this.button_job.Click += new System.EventHandler(this.button_job_Click);
            // 
            // groupBox_job
            // 
            this.groupBox_job.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_job.Controls.Add(this.button_job);
            this.groupBox_job.Location = new System.Drawing.Point(12, 404);
            this.groupBox_job.Name = "groupBox_job";
            this.groupBox_job.Size = new System.Drawing.Size(510, 70);
            this.groupBox_job.TabIndex = 6;
            this.groupBox_job.TabStop = false;
            this.groupBox_job.Text = "Job";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar_current,
            this.toolStripStatusLabel_current});
            this.statusStrip.Location = new System.Drawing.Point(0, 489);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(534, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Current file:";
            // 
            // toolStripProgressBar_current
            // 
            this.toolStripProgressBar_current.Name = "toolStripProgressBar_current";
            this.toolStripProgressBar_current.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar_current.Step = 1;
            // 
            // toolStripStatusLabel_current
            // 
            this.toolStripStatusLabel_current.Name = "toolStripStatusLabel_current";
            this.toolStripStatusLabel_current.Size = new System.Drawing.Size(0, 17);
            // 
            // timer_extract
            // 
            this.timer_extract.Tick += new System.EventHandler(this.timer_extract_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox_job);
            this.Controls.Add(this.groupBox_languages);
            this.Controls.Add(this.groupBox_mkvlist);
            this.Controls.Add(this.groupBox_toolnix);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "MainForm";
            this.Text = "MKS Extractor GUI - v1.0 - Made by rvbg.eu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_toolnix.ResumeLayout(false);
            this.groupBox_toolnix.PerformLayout();
            this.groupBox_mkvlist.ResumeLayout(false);
            this.groupBox_languages.ResumeLayout(false);
            this.groupBox_languages.PerformLayout();
            this.groupBox_job.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_toolnix;
        private System.Windows.Forms.TextBox textBox_toolnix_path;
        private System.Windows.Forms.Button button_toolnix_browse;
        private System.Windows.Forms.GroupBox groupBox_mkvlist;
        private System.Windows.Forms.ListBox listBox_mkvlist;
        private System.Windows.Forms.GroupBox groupBox_languages;
        private System.Windows.Forms.Button button_language_add;
        private System.Windows.Forms.TextBox textBox_language_add;
        private System.Windows.Forms.ListBox listBox_languages;
        private System.Windows.Forms.Button button_job;
        private System.Windows.Forms.GroupBox groupBox_job;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_current;
        private System.Windows.Forms.Timer timer_extract;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_current;
    }
}

