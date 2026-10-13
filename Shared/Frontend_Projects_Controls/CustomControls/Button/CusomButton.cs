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
using Frontend_Projects_Controls.Interfaces.Language;

namespace Frontend_Projects_Controls.CustomControls.Button
{
    public partial class cButton : System.Windows.Forms.Button,iLanguage
    {
        public cButton()
        {
            InitializeComponent();
            TextsDisplays = new Dictionary<Enums.enLanguage, string>();
        }

        private void _SetDisplayText()
        {
            TextsDisplays.TryGetValue(_Language, out var DisplayText);

            if (string.IsNullOrWhiteSpace(DisplayText)) return;

            Text = DisplayText;

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public Dictionary<Enums.enLanguage, string> TextsDisplays;

        private Enums.enLanguage _Language;

        public virtual Enums.enLanguage Language
        {
            get 
            {
                return _Language;
            }

            set
            {
                _Language = value;

                _SetDisplayText();
            }
        }

    }



        
}
