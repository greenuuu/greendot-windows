namespace ShadowSocks.View
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblHeaderHint = new System.Windows.Forms.Label();
            this.lblHeaderName = new System.Windows.Forms.Label();
            this.panForm = new System.Windows.Forms.Panel();
            this.btnFindPwd = new System.Windows.Forms.Button();
            this.panPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panPhone = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblFormPwd = new System.Windows.Forms.Label();
            this.lblFormPhone = new System.Windows.Forms.Label();
            this.panRegister = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegisterHint = new System.Windows.Forms.Label();
            this.panHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panForm.SuspendLayout();
            this.panPassword.SuspendLayout();
            this.panPhone.SuspendLayout();
            this.panRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.panHeader.Controls.Add(this.picLogo);
            this.panHeader.Controls.Add(this.lblHeaderHint);
            this.panHeader.Controls.Add(this.lblHeaderName);
            this.panHeader.Location = new System.Drawing.Point(0, 45);
            this.panHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(400, 199);
            this.panHeader.TabIndex = 12;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::ShadowSocks.Properties.Resources.logo_white;
            this.picLogo.Location = new System.Drawing.Point(160, 20);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(81, 79);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // lblHeaderHint
            // 
            this.lblHeaderHint.AutoSize = true;
            this.lblHeaderHint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeaderHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblHeaderHint.Location = new System.Drawing.Point(61, 156);
            this.lblHeaderHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderHint.Name = "lblHeaderHint";
            this.lblHeaderHint.Size = new System.Drawing.Size(280, 24);
            this.lblHeaderHint.TabIndex = 11;
            this.lblHeaderHint.Text = "要想生活过得去，上网必须带点绿";
            // 
            // lblHeaderName
            // 
            this.lblHeaderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderName.AutoSize = true;
            this.lblHeaderName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeaderName.ForeColor = System.Drawing.Color.White;
            this.lblHeaderName.Location = new System.Drawing.Point(132, 113);
            this.lblHeaderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderName.Name = "lblHeaderName";
            this.lblHeaderName.Size = new System.Drawing.Size(134, 31);
            this.lblHeaderName.TabIndex = 10;
            this.lblHeaderName.Text = "绿点加速器";
            // 
            // panForm
            // 
            this.panForm.BackColor = System.Drawing.Color.White;
            this.panForm.Controls.Add(this.btnFindPwd);
            this.panForm.Controls.Add(this.panPassword);
            this.panForm.Controls.Add(this.panPhone);
            this.panForm.Controls.Add(this.lblMessage);
            this.panForm.Controls.Add(this.btnLogin);
            this.panForm.Controls.Add(this.lblFormPwd);
            this.panForm.Controls.Add(this.lblFormPhone);
            this.panForm.Location = new System.Drawing.Point(0, 245);
            this.panForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panForm.Name = "panForm";
            this.panForm.Size = new System.Drawing.Size(400, 345);
            this.panForm.TabIndex = 13;
            // 
            // btnFindPwd
            // 
            this.btnFindPwd.FlatAppearance.BorderSize = 0;
            this.btnFindPwd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFindPwd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnFindPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindPwd.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnFindPwd.Location = new System.Drawing.Point(292, 291);
            this.btnFindPwd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFindPwd.Name = "btnFindPwd";
            this.btnFindPwd.Size = new System.Drawing.Size(95, 41);
            this.btnFindPwd.TabIndex = 4;
            this.btnFindPwd.TabStop = false;
            this.btnFindPwd.Text = "忘记密码";
            this.btnFindPwd.UseVisualStyleBackColor = true;
            this.btnFindPwd.Click += new System.EventHandler(this.btnFindPwd_Click);
            // 
            // panPassword
            // 
            this.panPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panPassword.Controls.Add(this.txtPassword);
            this.panPassword.Location = new System.Drawing.Point(22, 157);
            this.panPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panPassword.Name = "panPassword";
            this.panPassword.Size = new System.Drawing.Size(354, 48);
            this.panPassword.TabIndex = 2;
            this.panPassword.TabStop = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.Location = new System.Drawing.Point(15, 13);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.MaximumSize = new System.Drawing.Size(325, 34);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MinimumSize = new System.Drawing.Size(325, 34);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(325, 32);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // panPhone
            // 
            this.panPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panPhone.Controls.Add(this.txtPhone);
            this.panPhone.Location = new System.Drawing.Point(22, 60);
            this.panPhone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panPhone.Name = "panPhone";
            this.panPhone.Size = new System.Drawing.Size(354, 48);
            this.panPhone.TabIndex = 1;
            this.panPhone.TabStop = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPhone.Location = new System.Drawing.Point(15, 13);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPhone.MaximumSize = new System.Drawing.Size(325, 34);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.MinimumSize = new System.Drawing.Size(325, 34);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(325, 33);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(18, 299);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 24);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(22, 225);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLogin.MaximumSize = new System.Drawing.Size(354, 54);
            this.btnLogin.MinimumSize = new System.Drawing.Size(354, 54);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(354, 54);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblFormPwd
            // 
            this.lblFormPwd.AutoSize = true;
            this.lblFormPwd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblFormPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFormPwd.Location = new System.Drawing.Point(18, 122);
            this.lblFormPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormPwd.Name = "lblFormPwd";
            this.lblFormPwd.Size = new System.Drawing.Size(46, 24);
            this.lblFormPwd.TabIndex = 8;
            this.lblFormPwd.Text = "密码";
            // 
            // lblFormPhone
            // 
            this.lblFormPhone.AutoSize = true;
            this.lblFormPhone.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblFormPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFormPhone.Location = new System.Drawing.Point(18, 21);
            this.lblFormPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormPhone.Name = "lblFormPhone";
            this.lblFormPhone.Size = new System.Drawing.Size(82, 24);
            this.lblFormPhone.TabIndex = 9;
            this.lblFormPhone.Text = "手机号码";
            // 
            // panRegister
            // 
            this.panRegister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panRegister.Controls.Add(this.btnRegister);
            this.panRegister.Controls.Add(this.lblRegisterHint);
            this.panRegister.Location = new System.Drawing.Point(0, 590);
            this.panRegister.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panRegister.Name = "panRegister";
            this.panRegister.Size = new System.Drawing.Size(400, 80);
            this.panRegister.TabIndex = 14;
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.btnRegister.Location = new System.Drawing.Point(22, 20);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(119, 41);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.TabStop = false;
            this.btnRegister.Text = "新用户注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblRegisterHint
            // 
            this.lblRegisterHint.AutoSize = true;
            this.lblRegisterHint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRegisterHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            this.lblRegisterHint.Location = new System.Drawing.Point(187, 27);
            this.lblRegisterHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterHint.Name = "lblRegisterHint";
            this.lblRegisterHint.Size = new System.Drawing.Size(208, 24);
            this.lblRegisterHint.TabIndex = 13;
            this.lblRegisterHint.Text = "注册即送一个月免费使用";
            this.lblRegisterHint.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 670);
            this.Controls.Add(this.panRegister);
            this.Controls.Add(this.panForm);
            this.Controls.Add(this.panHeader);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panForm.ResumeLayout(false);
            this.panForm.PerformLayout();
            this.panPassword.ResumeLayout(false);
            this.panPassword.PerformLayout();
            this.panPhone.ResumeLayout(false);
            this.panPhone.PerformLayout();
            this.panRegister.ResumeLayout(false);
            this.panRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblHeaderHint;
        private System.Windows.Forms.Label lblHeaderName;
        private System.Windows.Forms.Panel panForm;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblFormPwd;
        private System.Windows.Forms.Label lblFormPhone;
        private System.Windows.Forms.Panel panRegister;
        private System.Windows.Forms.Label lblRegisterHint;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panPhone;
        private System.Windows.Forms.Panel panPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnFindPwd;
    }
}