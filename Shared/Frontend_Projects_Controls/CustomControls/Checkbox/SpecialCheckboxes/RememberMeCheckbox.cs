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

namespace Frontend_Projects_Controls.CustomControls.Checkbox
{
    public sealed partial class RememberMeCheckbox : cCheckbox
    {
        public RememberMeCheckbox()
        {
            InitializeComponent();

            TextsDisplays[Enums.enLanguage.eEnglish] = "Remember Me";
            TextsDisplays[Enums.enLanguage.eArabic] = "تذكرني";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}