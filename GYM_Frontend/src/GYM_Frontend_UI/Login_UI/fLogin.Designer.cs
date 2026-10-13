namespace GYM_Frontend_UI.Login_UI
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            ctrlLogin1 = new Frontend_Projects_Controls.UserControls.Login.ctrlLogin();
            SuspendLayout();
            // 
            // ctrlLogin1
            // 
            ctrlLogin1.BackColor = Color.White;
            ctrlLogin1.BorderStyle = BorderStyle.FixedSingle;
            ctrlLogin1.Language = Frontend_Projects_Controls.DataTypes.Enums.enLanguage.eEnglish;
            resources.ApplyResources(ctrlLogin1, "ctrlLogin1");
            ctrlLogin1.LoginData = Frontend_Projects_Controls.CustomControls.Textbox.SpecialTextboxes.LoginValueTextbox.enLoginData.eEmail;
            ctrlLogin1.Name = "ctrlLogin1";
            ctrlLogin1.OnLogin += ctrlLogin1_OnLogin;
            // 
            // fLogin
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ctrlLogin1);
            Name = "fLogin";
            TitleFont = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Controls.SetChildIndex(ctrlLogin1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Frontend_Projects_Controls.UserControls.Login.ctrlLogin ctrlLogin1;
    }
}