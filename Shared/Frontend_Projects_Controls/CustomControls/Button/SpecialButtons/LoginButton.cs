using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend_Projects_Controls.DataTypes;

namespace Frontend_Projects_Controls.CustomControls.Button.SpecialButtons
{
    public sealed partial class LoginButton : cButton
    {
        public LoginButton()
        {
            InitializeComponent();

            TextsDisplays[Enums.enLanguage.eEnglish] = "Login";
            TextsDisplays[Enums.enLanguage.eArabic] = "تسجيل الدخول";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}