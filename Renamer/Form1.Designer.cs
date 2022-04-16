
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
            this.lbImage = new System.Windows.Forms.PictureBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnStopAPI = new System.Windows.Forms.Button();
            this.lbBlacklist = new System.Windows.Forms.Label();
            this.tbBlacklist = new System.Windows.Forms.TextBox();
            this.rbFilter = new System.Windows.Forms.RadioButton();
            this.rbRaw = new System.Windows.Forms.RadioButton();
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).BeginInit();
            this.gbMethod.SuspendLayout();
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
            this.toolStripLbPathInfo.ReadOnly = true;
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
            this.before.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.before.HeaderText = "before";
            this.before.Name = "before";
            this.before.ReadOnly = true;
            this.before.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // after
            // 
            this.after.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.after.HeaderText = "after";
            this.after.Name = "after";
            this.after.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnRunAPI
            // 
            this.btnRunAPI.Location = new System.Drawing.Point(678, 197);
            this.btnRunAPI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRunAPI.Name = "btnRunAPI";
            this.btnRunAPI.Size = new System.Drawing.Size(88, 27);
            this.btnRunAPI.TabIndex = 2;
            this.btnRunAPI.Text = "Detect Text";
            this.btnRunAPI.UseVisualStyleBackColor = true;
            this.btnRunAPI.Click += new System.EventHandler(this.btnRunAPI_Click);
            // 
            // btnRefreash
            // 
            this.btnRefreash.Location = new System.Drawing.Point(784, 230);
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
            this.btnRenameAll.Location = new System.Drawing.Point(784, 197);
            this.btnRenameAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.Size = new System.Drawing.Size(88, 27);
            this.btnRenameAll.TabIndex = 4;
            this.btnRenameAll.Text = "Rename all";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // lbImage
            // 
            this.lbImage.Location = new System.Drawing.Point(678, 291);
            this.lbImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(316, 289);
            this.lbImage.TabIndex = 6;
            this.lbImage.TabStop = false;
            // 
            // tbConsole
            // 
            this.tbConsole.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbConsole.Location = new System.Drawing.Point(14, 54);
            this.tbConsole.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(397, 84);
            this.tbConsole.TabIndex = 7;
            // 
            // btnStopAPI
            // 
            this.btnStopAPI.Location = new System.Drawing.Point(678, 230);
            this.btnStopAPI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopAPI.Name = "btnStopAPI";
            this.btnStopAPI.Size = new System.Drawing.Size(88, 27);
            this.btnStopAPI.TabIndex = 13;
            this.btnStopAPI.Text = "Stop";
            this.btnStopAPI.UseVisualStyleBackColor = true;
            this.btnStopAPI.Click += new System.EventHandler(this.btnStopAPI_Click);
            // 
            // lbBlacklist
            // 
            this.lbBlacklist.AutoSize = true;
            this.lbBlacklist.Location = new System.Drawing.Point(141, 19);
            this.lbBlacklist.Name = "lbBlacklist";
            this.lbBlacklist.Size = new System.Drawing.Size(50, 15);
            this.lbBlacklist.TabIndex = 9;
            this.lbBlacklist.Text = "Blacklist";
            // 
            // tbBlacklist
            // 
            this.tbBlacklist.Location = new System.Drawing.Point(141, 35);
            this.tbBlacklist.Name = "tbBlacklist";
            this.tbBlacklist.Size = new System.Drawing.Size(382, 23);
            this.tbBlacklist.TabIndex = 8;
            this.tbBlacklist.TextChanged += new System.EventHandler(this.tbBlacklist_TextChanged);
            // 
            // rbFilter
            // 
            this.rbFilter.AutoSize = true;
            this.rbFilter.Location = new System.Drawing.Point(26, 39);
            this.rbFilter.Name = "rbFilter";
            this.rbFilter.Size = new System.Drawing.Size(71, 19);
            this.rbFilter.TabIndex = 10;
            this.rbFilter.TabStop = true;
            this.rbFilter.Text = "Use filter";
            this.rbFilter.UseVisualStyleBackColor = true;
            // 
            // rbRaw
            // 
            this.rbRaw.AutoSize = true;
            this.rbRaw.Location = new System.Drawing.Point(26, 88);
            this.rbRaw.Name = "rbRaw";
            this.rbRaw.Size = new System.Drawing.Size(89, 19);
            this.rbRaw.TabIndex = 11;
            this.rbRaw.TabStop = true;
            this.rbRaw.Text = "Use raw text";
            this.rbRaw.UseVisualStyleBackColor = true;
            this.rbRaw.CheckedChanged += new System.EventHandler(this.rbRaw_CheckedChanged);
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.rbRaw);
            this.gbMethod.Controls.Add(this.tbBlacklist);
            this.gbMethod.Controls.Add(this.lbBlacklist);
            this.gbMethod.Controls.Add(this.rbFilter);
            this.gbMethod.Location = new System.Drawing.Point(506, 40);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Size = new System.Drawing.Size(534, 121);
            this.gbMethod.TabIndex = 12;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "Choose method";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 623);
            this.Controls.Add(this.btnStopAPI);
            this.Controls.Add(this.gbMethod);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.btnRenameAll);
            this.Controls.Add(this.btnRefreash);
            this.Controls.Add(this.btnRunAPI);
            this.Controls.Add(this.dgRename);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Renamer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).EndInit();
            this.gbMethod.ResumeLayout(false);
            this.gbMethod.PerformLayout();
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
        private System.Windows.Forms.PictureBox lbImage;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.ToolStripTextBox toolStripLbPathInfo;
        private System.Windows.Forms.Button btnStopAPI;
        private System.Windows.Forms.Label lbBlacklist;
        private System.Windows.Forms.TextBox tbBlacklist;
        private System.Windows.Forms.RadioButton rbFilter;
        private System.Windows.Forms.RadioButton rbRaw;
        private System.Windows.Forms.GroupBox gbMethod;
    }
}

