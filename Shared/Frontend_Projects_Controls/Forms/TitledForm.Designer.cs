namespace Frontend_Projects_Controls.Forms
{
    partial class TitledForm
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
            txtTitle = new CustomControls.Label.TitleLabel();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.Blue;
            txtTitle.Language = DataTypes.Enums.enLanguage.eArabic;
            txtTitle.Location = new Point(350, 10);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 50);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "Title";
            // 
            // TitledForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTitle);
            Name = "TitledForm";
            Text = "TitledForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.Label.TitleLabel txtTitle;
    }
}