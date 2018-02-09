namespace ShadowSocks.View
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.panSystem = new System.Windows.Forms.Panel();
            this.chkLAN = new System.Windows.Forms.CheckBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.lblSystem = new System.Windows.Forms.Label();
            this.panPac = new System.Windows.Forms.Panel();
            this.lblPac = new System.Windows.Forms.Label();
            this.btnPacRemote = new System.Windows.Forms.Button();
            this.btnPacEdit = new System.Windows.Forms.Button();
            this.panBottom = new System.Windows.Forms.Panel();
            this.lblAbout = new System.Windows.Forms.Label();
            this.picAbout = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.panUpdate = new System.Windows.Forms.Panel();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panSystem.SuspendLayout();
            this.panPac.SuspendLayout();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.panUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.AutoSize = true;
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(11, 11);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(52, 27);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "配置";
            // 
            // panSystem
            // 
            this.panSystem.BackColor = System.Drawing.Color.White;
            this.panSystem.Controls.Add(this.chkLAN);
            this.panSystem.Controls.Add(this.btnLog);
            this.panSystem.Controls.Add(this.chkAutoRun);
            this.panSystem.Controls.Add(this.lblSystem);
            this.panSystem.Location = new System.Drawing.Point(0, 45);
            this.panSystem.Name = "panSystem";
            this.panSystem.Size = new System.Drawing.Size(400, 222);
            this.panSystem.TabIndex = 0;
            this.panSystem.TabStop = true;
            // 
            // chkLAN
            // 
            this.chkLAN.AutoSize = true;
            this.chkLAN.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLAN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chkLAN.Location = new System.Drawing.Point(25, 102);
            this.chkLAN.Name = "chkLAN";
            this.chkLAN.Size = new System.Drawing.Size(198, 28);
            this.chkLAN.TabIndex = 2;
            this.chkLAN.Text = "是否允许局域网连接";
            this.chkLAN.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLog.Location = new System.Drawing.Point(25, 145);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(350, 50);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "查看运行日志";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.FlatAppearance.BorderSize = 0;
            this.chkAutoRun.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAutoRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chkAutoRun.Location = new System.Drawing.Point(25, 64);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(108, 28);
            this.chkAutoRun.TabIndex = 1;
            this.chkAutoRun.Text = "开机启动";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // lblSystem
            // 
            this.lblSystem.AutoSize = true;
            this.lblSystem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystem.ForeColor = System.Drawing.Color.DimGray;
            this.lblSystem.Location = new System.Drawing.Point(12, 24);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(82, 24);
            this.lblSystem.TabIndex = 1;
            this.lblSystem.Text = "系统配置";
            // 
            // panPac
            // 
            this.panPac.BackColor = System.Drawing.Color.White;
            this.panPac.Controls.Add(this.lblPac);
            this.panPac.Controls.Add(this.btnPacRemote);
            this.panPac.Controls.Add(this.btnPacEdit);
            this.panPac.Location = new System.Drawing.Point(0, 267);
            this.panPac.Name = "panPac";
            this.panPac.Size = new System.Drawing.Size(400, 196);
            this.panPac.TabIndex = 1;
            this.panPac.TabStop = true;
            // 
            // lblPac
            // 
            this.lblPac.AutoSize = true;
            this.lblPac.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPac.ForeColor = System.Drawing.Color.DimGray;
            this.lblPac.Location = new System.Drawing.Point(12, 3);
            this.lblPac.Name = "lblPac";
            this.lblPac.Size = new System.Drawing.Size(82, 24);
            this.lblPac.TabIndex = 3;
            this.lblPac.Text = "智能配置";
            // 
            // btnPacRemote
            // 
            this.btnPacRemote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnPacRemote.FlatAppearance.BorderSize = 0;
            this.btnPacRemote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnPacRemote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnPacRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacRemote.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPacRemote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPacRemote.Location = new System.Drawing.Point(25, 118);
            this.btnPacRemote.Name = "btnPacRemote";
            this.btnPacRemote.Size = new System.Drawing.Size(350, 50);
            this.btnPacRemote.TabIndex = 6;
            this.btnPacRemote.Text = "从官方更新本地PAC文件";
            this.btnPacRemote.UseVisualStyleBackColor = false;
            this.btnPacRemote.Click += new System.EventHandler(this.btnPacRemote_Click);
            // 
            // btnPacEdit
            // 
            this.btnPacEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnPacEdit.FlatAppearance.BorderSize = 0;
            this.btnPacEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnPacEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnPacEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacEdit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPacEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPacEdit.Location = new System.Drawing.Point(25, 46);
            this.btnPacEdit.Name = "btnPacEdit";
            this.btnPacEdit.Size = new System.Drawing.Size(350, 50);
            this.btnPacEdit.TabIndex = 5;
            this.btnPacEdit.Text = "编辑本地PAC文件";
            this.btnPacEdit.UseVisualStyleBackColor = false;
            this.btnPacEdit.Click += new System.EventHandler(this.btnPacEdit_Click);
            // 
            // panBottom
            // 
            this.panBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panBottom.Controls.Add(this.lblAbout);
            this.panBottom.Controls.Add(this.picAbout);
            this.panBottom.Controls.Add(this.btnProfile);
            this.panBottom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panBottom.Location = new System.Drawing.Point(0, 582);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(400, 70);
            this.panBottom.TabIndex = 3;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.lblAbout.Location = new System.Drawing.Point(51, 25);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(82, 24);
            this.lblAbout.TabIndex = 2;
            this.lblAbout.Text = "官方网站";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // picAbout
            // 
            this.picAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAbout.Image = global::ShadowSocks.Properties.Resources.logo;
            this.picAbout.Location = new System.Drawing.Point(25, 27);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(22, 22);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAbout.TabIndex = 1;
            this.picAbout.TabStop = false;
            this.picAbout.Click += new System.EventHandler(this.picAbout_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProfile.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnProfile.Location = new System.Drawing.Point(261, 15);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(114, 40);
            this.btnProfile.TabIndex = 8;
            this.btnProfile.Text = "个人中心";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // panUpdate
            // 
            this.panUpdate.BackColor = System.Drawing.Color.White;
            this.panUpdate.Controls.Add(this.lblUpdate);
            this.panUpdate.Controls.Add(this.btnUpdate);
            this.panUpdate.Location = new System.Drawing.Point(0, 463);
            this.panUpdate.Name = "panUpdate";
            this.panUpdate.Size = new System.Drawing.Size(400, 119);
            this.panUpdate.TabIndex = 2;
            this.panUpdate.TabStop = true;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdate.ForeColor = System.Drawing.Color.DimGray;
            this.lblUpdate.Location = new System.Drawing.Point(12, 3);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(82, 24);
            this.lblUpdate.TabIndex = 0;
            this.lblUpdate.Text = "软件更新";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUpdate.Location = new System.Drawing.Point(25, 43);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(350, 50);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "检查更新";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 652);
            this.Controls.Add(this.panUpdate);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panPac);
            this.Controls.Add(this.panSystem);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 680);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 652);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panSystem.ResumeLayout(false);
            this.panSystem.PerformLayout();
            this.panPac.ResumeLayout(false);
            this.panPac.PerformLayout();
            this.panBottom.ResumeLayout(false);
            this.panBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.panUpdate.ResumeLayout(false);
            this.panUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.Panel panSystem;
        private System.Windows.Forms.Panel panPac;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.CheckBox chkLAN;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.Label lblPac;
        private System.Windows.Forms.Button btnPacRemote;
        private System.Windows.Forms.Button btnPacEdit;
        private System.Windows.Forms.PictureBox picAbout;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Panel panUpdate;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Button btnUpdate;
    }
}