
namespace Renamer
{
    partial class MainForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnOpenAuth = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLbPathInfo = new System.Windows.Forms.ToolStripTextBox();
            this.dgRename = new System.Windows.Forms.DataGridView();
            this.before = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.after = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRunAPI = new System.Windows.Forms.Button();
            this.btnRefreash = new System.Windows.Forms.Button();
            this.btnRenameAll = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbImage = new System.Windows.Forms.PictureBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnOpenFolder,
            this.toolStripbtnOpenAuth,
            this.toolStripProgressBar,
            this.toolStripLbPathInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1074, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtnOpenFolder
            // 
            this.toolStripbtnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripbtnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnOpenFolder.Name = "toolStripbtnOpenFolder";
            this.toolStripbtnOpenFolder.Size = new System.Drawing.Size(74, 25);
            this.toolStripbtnOpenFolder.Text = "Open folder";
            this.toolStripbtnOpenFolder.Click += new System.EventHandler(this.toolStripbtnOpenFolder_Click);
            // 
            // toolStripbtnOpenAuth
            // 
            this.toolStripbtnOpenAuth.AutoToolTip = false;
            this.toolStripbtnOpenAuth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripbtnOpenAuth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnOpenAuth.Name = "toolStripbtnOpenAuth";
            this.toolStripbtnOpenAuth.Size = new System.Drawing.Size(149, 25);
            this.toolStripbtnOpenAuth.Text = "Set Google APi credentials";
            this.toolStripbtnOpenAuth.Click += new System.EventHandler(this.toolStripbtnOpenAuth_Click);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripProgressBar.Size = new System.Drawing.Size(117, 25);
            // 
            // toolStripLbPathInfo
            // 
            this.toolStripLbPathInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLbPathInfo.Name = "toolStripLbPathInfo";
            this.toolStripLbPathInfo.Size = new System.Drawing.Size(116, 28);
            // 
            // dgRename
            // 
            this.dgRename.AllowUserToAddRows = false;
            this.dgRename.AllowUserToDeleteRows = false;
            this.dgRename.BackgroundColor = System.Drawing.Color.White;
            this.dgRename.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRename.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.before,
            this.after});
            this.dgRename.Location = new System.Drawing.Point(14, 205);
            this.dgRename.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgRename.Name = "dgRename";
            this.dgRename.Size = new System.Drawing.Size(581, 375);
            this.dgRename.TabIndex = 1;
            this.dgRename.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRename_CellClick);
            this.dgRename.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRename_CellValueChanged);
            // 
            // before
            // 
            this.before.HeaderText = "before";
            this.before.Name = "before";
            this.before.ReadOnly = true;
            // 
            // after
            // 
            this.after.HeaderText = "after";
            this.after.Name = "after";
            // 
            // btnRunAPI
            // 
            this.btnRunAPI.Location = new System.Drawing.Point(678, 111);
            this.btnRunAPI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRunAPI.Name = "btnRunAPI";
            this.btnRunAPI.Size = new System.Drawing.Size(88, 27);
            this.btnRunAPI.TabIndex = 2;
            this.btnRunAPI.Text = "Run API";
            this.btnRunAPI.UseVisualStyleBackColor = true;
            this.btnRunAPI.Click += new System.EventHandler(this.btnRunAPI_Click);
            // 
            // btnRefreash
            // 
            this.btnRefreash.Location = new System.Drawing.Point(678, 144);
            this.btnRefreash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(88, 27);
            this.btnRefreash.TabIndex = 3;
            this.btnRefreash.Text = "Refreash";
            this.btnRefreash.UseVisualStyleBackColor = true;
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // btnRenameAll
            // 
            this.btnRenameAll.Location = new System.Drawing.Point(785, 111);
            this.btnRenameAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.Size = new System.Drawing.Size(88, 27);
            this.btnRenameAll.TabIndex = 4;
            this.btnRenameAll.Text = "Rename all";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(923, 117);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(22, 15);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = ".....";
            // 
            // lbImage
            // 
            this.lbImage.Location = new System.Drawing.Point(653, 205);
            this.lbImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(365, 375);
            this.lbImage.TabIndex = 6;
            this.lbImage.TabStop = false;
            // 
            // tbConsole
            // 
            this.tbConsole.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbConsole.Location = new System.Drawing.Point(14, 48);
            this.tbConsole.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(453, 122);
            this.tbConsole.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 623);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnRenameAll);
            this.Controls.Add(this.btnRefreash);
            this.Controls.Add(this.btnRunAPI);
            this.Controls.Add(this.dgRename);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtnOpenFolder;
        private System.Windows.Forms.ToolStripButton toolStripbtnOpenAuth;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.DataGridView dgRename;
        private System.Windows.Forms.DataGridViewTextBoxColumn before;
        private System.Windows.Forms.DataGridViewTextBoxColumn after;
        private System.Windows.Forms.Button btnRunAPI;
        private System.Windows.Forms.Button btnRefreash;
        private System.Windows.Forms.Button btnRenameAll;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.PictureBox lbImage;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.ToolStripTextBox toolStripLbPathInfo;
    }
}

