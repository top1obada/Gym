namespace Frontend_Projects_Controls.UserControls.Login
{
    partial class ctrlLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPassword = new CustomControls.Textbox.SpecialTextboxes.PassswordTextbox();
            btnLogin = new CustomControls.Button.SpecialButtons.LoginButton();
            cbRememberMe = new CustomControls.Checkbox.RememberMeCheckbox();
            txtLoginData = new CustomControls.Textbox.SpecialTextboxes.LoginValueTextbox();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Language = DataTypes.Enums.enLanguage.eEnglish;
            txtPassword.Location = new Point(157, 109);
            txtPassword.Name = "txtPassword";
            txtPassword.Required = true;
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.Size = new Size(285, 38);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "Password";
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.SteelBlue;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Language = DataTypes.Enums.enLanguage.eEnglish;
            btnLogin.Location = new Point(216, 202);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(166, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbRememberMe
            // 
            cbRememberMe.AutoSize = true;
            cbRememberMe.Checked = true;
            cbRememberMe.CheckState = CheckState.Checked;
            cbRememberMe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbRememberMe.ForeColor = Color.Blue;
            cbRememberMe.Language = DataTypes.Enums.enLanguage.eEnglish;
            cbRememberMe.Location = new Point(157, 163);
            cbRememberMe.Name = "cbRememberMe";
            cbRememberMe.RightToLeft = RightToLeft.No;
            cbRememberMe.Size = new Size(134, 24);
            cbRememberMe.TabIndex = 2;
            cbRememberMe.Text = "Remember Me";
            cbRememberMe.UseVisualStyleBackColor = true;
            // 
            // txtLoginData
            // 
            txtLoginData.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLoginData.ForeColor = Color.Gray;
            txtLoginData.Language = DataTypes.Enums.enLanguage.eEnglish;
            txtLoginData.Location = new Point(157, 45);
            txtLoginData.LoginData = CustomControls.Textbox.SpecialTextboxes.LoginValueTextbox.enLoginData.eEmail;
            txtLoginData.Name = "txtLoginData";
            txtLoginData.Required = true;
            txtLoginData.RightToLeft = RightToLeft.No;
            txtLoginData.Size = new Size(285, 38);
            txtLoginData.TabIndex = 0;
            txtLoginData.Text = "Email";
            // 
            // ctrlLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtLoginData);
            Controls.Add(cbRememberMe);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Name = "ctrlLogin";
            Size = new Size(597, 288);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.Textbox.SpecialTextboxes.PassswordTextbox txtPassword;
        private CustomControls.Button.SpecialButtons.LoginButton btnLogin;
        private CustomControls.Checkbox.RememberMeCheckbox cbRememberMe;
        private CustomControls.Textbox.SpecialTextboxes.LoginValueTextbox txtLoginData;
    }
}
