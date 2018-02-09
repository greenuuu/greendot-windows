namespace ShadowSocks.View
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.panHeader = new System.Windows.Forms.Panel();
            this.lblExpiredDate = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picUserStatus = new System.Windows.Forms.PictureBox();
            this.picUserAvatar = new System.Windows.Forms.PictureBox();
            this.lblExpiredHint = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panControl = new System.Windows.Forms.Panel();
            this.panBorder = new System.Windows.Forms.Panel();
            this.btnPacStart = new System.Windows.Forms.Button();
            this.btnGlobalStart = new System.Windows.Forms.Button();
            this.panServers = new System.Windows.Forms.Panel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.panSubHeader = new System.Windows.Forms.Panel();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblServerHint = new System.Windows.Forms.Label();
            this.panSetting = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.picStatusStop = new System.Windows.Forms.PictureBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.panHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            this.panControl.SuspendLayout();
            this.panServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.panSubHeader.SuspendLayout();
            this.panSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.AutoSize = true;
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(11, 11);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(112, 27);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "绿点加速器";
            // 
            // panHeader
            // 
            this.panHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.panHeader.Controls.Add(this.lblExpiredDate);
            this.panHeader.Controls.Add(this.btnLogout);
            this.panHeader.Controls.Add(this.picUserStatus);
            this.panHeader.Controls.Add(this.picUserAvatar);
            this.panHeader.Controls.Add(this.lblExpiredHint);
            this.panHeader.Controls.Add(this.lblUserName);
            this.panHeader.Location = new System.Drawing.Point(0, 45);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(400, 100);
            this.panHeader.TabIndex = 0;
            // 
            // lblExpiredDate
            // 
            this.lblExpiredDate.AutoSize = true;
            this.lblExpiredDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExpiredDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.lblExpiredDate.Location = new System.Drawing.Point(181, 57);
            this.lblExpiredDate.Name = "lblExpiredDate";
            this.lblExpiredDate.Size = new System.Drawing.Size(29, 24);
            this.lblExpiredDate.TabIndex = 8;
            this.lblExpiredDate.Text = "—";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(184)))), ((int)(((byte)(106)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(184)))), ((int)(((byte)(106)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnLogout.Location = new System.Drawing.Point(317, 48);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(64, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.TabStop = false;
            this.btnLogout.Text = "退出";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // picUserStatus
            // 
            this.picUserStatus.BackColor = System.Drawing.Color.Transparent;
            this.picUserStatus.Image = ((System.Drawing.Image)(resources.GetObject("picUserStatus.Image")));
            this.picUserStatus.Location = new System.Drawing.Point(249, 28);
            this.picUserStatus.MaximumSize = new System.Drawing.Size(20, 20);
            this.picUserStatus.MinimumSize = new System.Drawing.Size(20, 20);
            this.picUserStatus.Name = "picUserStatus";
            this.picUserStatus.Size = new System.Drawing.Size(20, 20);
            this.picUserStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserStatus.TabIndex = 7;
            this.picUserStatus.TabStop = false;
            this.picUserStatus.Visible = false;
            // 
            // picUserAvatar
            // 
            this.picUserAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUserAvatar.Image = global::ShadowSocks.Properties.Resources.logo_white;
            this.picUserAvatar.Location = new System.Drawing.Point(20, 22);
            this.picUserAvatar.MaximumSize = new System.Drawing.Size(60, 60);
            this.picUserAvatar.MinimumSize = new System.Drawing.Size(60, 60);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.Size = new System.Drawing.Size(60, 60);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserAvatar.TabIndex = 6;
            this.picUserAvatar.TabStop = false;
            this.picUserAvatar.Click += new System.EventHandler(this.picUserAvatar_Click);
            // 
            // lblExpiredHint
            // 
            this.lblExpiredHint.AutoSize = true;
            this.lblExpiredHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblExpiredHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.lblExpiredHint.Location = new System.Drawing.Point(90, 56);
            this.lblExpiredHint.Name = "lblExpiredHint";
            this.lblExpiredHint.Size = new System.Drawing.Size(100, 24);
            this.lblExpiredHint.TabIndex = 4;
            this.lblExpiredHint.Text = "服务过期：";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblUserName.Location = new System.Drawing.Point(88, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(168, 31);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "13540312451";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // panControl
            // 
            this.panControl.BackColor = System.Drawing.Color.White;
            this.panControl.Controls.Add(this.panBorder);
            this.panControl.Controls.Add(this.btnPacStart);
            this.panControl.Controls.Add(this.btnGlobalStart);
            this.panControl.Location = new System.Drawing.Point(0, 557);
            this.panControl.MaximumSize = new System.Drawing.Size(400, 100);
            this.panControl.MinimumSize = new System.Drawing.Size(400, 100);
            this.panControl.Name = "panControl";
            this.panControl.Size = new System.Drawing.Size(400, 100);
            this.panControl.TabIndex = 0;
            // 
            // panBorder
            // 
            this.panBorder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panBorder.Location = new System.Drawing.Point(0, 0);
            this.panBorder.Name = "panBorder";
            this.panBorder.Size = new System.Drawing.Size(400, 1);
            this.panBorder.TabIndex = 4;
            // 
            // btnPacStart
            // 
            this.btnPacStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.btnPacStart.FlatAppearance.BorderSize = 0;
            this.btnPacStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacStart.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPacStart.ForeColor = System.Drawing.Color.White;
            this.btnPacStart.Location = new System.Drawing.Point(211, 23);
            this.btnPacStart.MaximumSize = new System.Drawing.Size(170, 54);
            this.btnPacStart.MinimumSize = new System.Drawing.Size(170, 54);
            this.btnPacStart.Name = "btnPacStart";
            this.btnPacStart.Size = new System.Drawing.Size(170, 54);
            this.btnPacStart.TabIndex = 2;
            this.btnPacStart.TabStop = false;
            this.btnPacStart.Text = "智能加速";
            this.btnPacStart.UseVisualStyleBackColor = false;
            this.btnPacStart.Click += new System.EventHandler(this.btnPacStart_Click);
            // 
            // btnGlobalStart
            // 
            this.btnGlobalStart.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGlobalStart.FlatAppearance.BorderSize = 0;
            this.btnGlobalStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlobalStart.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnGlobalStart.ForeColor = System.Drawing.Color.White;
            this.btnGlobalStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGlobalStart.Location = new System.Drawing.Point(19, 23);
            this.btnGlobalStart.MaximumSize = new System.Drawing.Size(170, 54);
            this.btnGlobalStart.MinimumSize = new System.Drawing.Size(170, 54);
            this.btnGlobalStart.Name = "btnGlobalStart";
            this.btnGlobalStart.Size = new System.Drawing.Size(170, 54);
            this.btnGlobalStart.TabIndex = 1;
            this.btnGlobalStart.TabStop = false;
            this.btnGlobalStart.Text = "全局加速";
            this.btnGlobalStart.UseVisualStyleBackColor = false;
            this.btnGlobalStart.Click += new System.EventHandler(this.btnGlobalStart_Click);
            // 
            // panServers
            // 
            this.panServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panServers.AutoScroll = true;
            this.panServers.BackColor = System.Drawing.Color.White;
            this.panServers.Controls.Add(this.picLoading);
            this.panServers.Location = new System.Drawing.Point(0, 215);
            this.panServers.Name = "panServers";
            this.panServers.Size = new System.Drawing.Size(400, 345);
            this.panServers.TabIndex = 0;
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(168, 136);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(64, 72);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 0;
            this.picLoading.TabStop = false;
            // 
            // panSubHeader
            // 
            this.panSubHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panSubHeader.Controls.Add(this.btnRecharge);
            this.panSubHeader.Controls.Add(this.lblHint);
            this.panSubHeader.Controls.Add(this.lblServerHint);
            this.panSubHeader.Location = new System.Drawing.Point(0, 145);
            this.panSubHeader.Name = "panSubHeader";
            this.panSubHeader.Size = new System.Drawing.Size(400, 70);
            this.panSubHeader.TabIndex = 0;
            // 
            // btnRecharge
            // 
            this.btnRecharge.AutoSize = true;
            this.btnRecharge.BackColor = System.Drawing.Color.Transparent;
            this.btnRecharge.FlatAppearance.BorderSize = 0;
            this.btnRecharge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnRecharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnRecharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecharge.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecharge.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnRecharge.Location = new System.Drawing.Point(317, 16);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(64, 40);
            this.btnRecharge.TabIndex = 0;
            this.btnRecharge.TabStop = false;
            this.btnRecharge.Text = "续费";
            this.btnRecharge.UseVisualStyleBackColor = false;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHint.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblHint.Location = new System.Drawing.Point(238, 24);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(0, 24);
            this.lblHint.TabIndex = 2;
            this.lblHint.Visible = false;
            // 
            // lblServerHint
            // 
            this.lblServerHint.AutoSize = true;
            this.lblServerHint.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblServerHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblServerHint.Location = new System.Drawing.Point(13, 24);
            this.lblServerHint.Name = "lblServerHint";
            this.lblServerHint.Size = new System.Drawing.Size(82, 24);
            this.lblServerHint.TabIndex = 0;
            this.lblServerHint.Text = "可用节点";
            // 
            // panSetting
            // 
            this.panSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panSetting.Controls.Add(this.btnSetting);
            this.panSetting.Controls.Add(this.picStatusStop);
            this.panSetting.Controls.Add(this.picStatus);
            this.panSetting.Location = new System.Drawing.Point(0, 657);
            this.panSetting.Name = "panSetting";
            this.panSetting.Size = new System.Drawing.Size(400, 63);
            this.panSetting.TabIndex = 0;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnSetting.Location = new System.Drawing.Point(317, 11);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(64, 40);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.TabStop = false;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // picStatusStop
            // 
            this.picStatusStop.Image = global::ShadowSocks.Properties.Resources.ico_connection_stop;
            this.picStatusStop.Location = new System.Drawing.Point(23, 22);
            this.picStatusStop.Name = "picStatusStop";
            this.picStatusStop.Size = new System.Drawing.Size(60, 20);
            this.picStatusStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatusStop.TabIndex = 5;
            this.picStatusStop.TabStop = false;
            // 
            // picStatus
            // 
            this.picStatus.Image = global::ShadowSocks.Properties.Resources.ico_connecting;
            this.picStatus.Location = new System.Drawing.Point(23, 22);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(60, 20);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 4;
            this.picStatus.TabStop = false;
            this.picStatus.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 720);
            this.Controls.Add(this.panSetting);
            this.Controls.Add(this.panSubHeader);
            this.Controls.Add(this.panControl);
            this.Controls.Add(this.panServers);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 720);
            this.MinimumSize = new System.Drawing.Size(400, 720);
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            this.panControl.ResumeLayout(false);
            this.panServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.panSubHeader.ResumeLayout(false);
            this.panSubHeader.PerformLayout();
            this.panSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.PictureBox picUserStatus;
        private System.Windows.Forms.PictureBox picUserAvatar;
        private System.Windows.Forms.Label lblExpiredHint;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panControl;
        private System.Windows.Forms.Button btnGlobalStart;
        private System.Windows.Forms.Panel panServers;
        private System.Windows.Forms.Panel panSubHeader;
        private System.Windows.Forms.Label lblServerHint;
        private System.Windows.Forms.Button btnPacStart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panSetting;
        private System.Windows.Forms.Panel panBorder;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.PictureBox picStatusStop;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblExpiredDate;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Button btnSetting;
    }
}