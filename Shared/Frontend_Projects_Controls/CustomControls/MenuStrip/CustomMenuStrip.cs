using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend_Projects_Controls.Data;
using Frontend_Projects_Controls.DataTypes;
using Frontend_Projects_Controls.Interfaces.Language;

namespace Frontend_Projects_Controls.CustomControls.MenuStrip
{
    public partial class cMenuStrip : System.Windows.Forms.MenuStrip,iLanguage
    {
        public cMenuStrip()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private readonly clsGroupInterfacesImplementaion _GroupInterfacesImplementaion;

        public virtual Enums.enLanguage Language
        {

            get { return _GroupInterfacesImplementaion.Language; }

            set
            {
                _GroupInterfacesImplementaion.Language = value;
            }
        }

    }
}
