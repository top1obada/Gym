using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Frontend_Projects_Controls.DataTypes;
using Frontend_Projects_Controls.Interfaces.Language;

namespace Frontend_Projects_Controls.CustomControls.Label
{
    public partial class cLabel : System.Windows.Forms.Label,iLanguage
    {
        public cLabel()
        {
            InitializeComponent();
       
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private Enums.enLanguage _Language = Enums.enLanguage.eEnglish;

        public readonly Dictionary<Enums.enLanguage, string> TextsDisplaies = 
            new Dictionary<Enums.enLanguage, string>();

        public Enums.enLanguage Language
        {
            get { return _Language; }

            set
            {
                _Language = value;

                if(TextsDisplaies.TryGetValue(value,out var Result))
                {
                    Text = Result;
                }
            }
        }

    }
}
