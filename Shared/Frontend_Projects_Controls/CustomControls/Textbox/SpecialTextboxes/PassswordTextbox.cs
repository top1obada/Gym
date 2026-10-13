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

namespace Frontend_Projects_Controls.CustomControls.Textbox.SpecialTextboxes
{
    public sealed partial class PassswordTextbox : cDisplayTextbox
    {
        public PassswordTextbox()
        {
            InitializeComponent();

            TextsDisplays[Enums.enLanguage.eEnglish] = "Password";
            TextsDisplays[Enums.enLanguage.eArabic] = "كلمة المرور";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}