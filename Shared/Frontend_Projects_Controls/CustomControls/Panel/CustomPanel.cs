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
using Frontend_Projects_Controls.Interfaces.Valid;

namespace Frontend_Projects_Controls.CustomControls.Panel
{
    public partial class CustomPanel : System.Windows.Forms.Panel,iLanguage,iValid
    {
        public CustomPanel()
        {
            InitializeComponent();
            _GroupInterfacesImplementaion = new clsGroupInterfacesImplementaion(this);
        }

        private readonly clsGroupInterfacesImplementaion _GroupInterfacesImplementaion;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        

        public virtual Enums.enLanguage Language
        {
            get { return _GroupInterfacesImplementaion.Language; }

            set
            {
                _GroupInterfacesImplementaion.Language = value;

            }
        }

        public virtual bool IsValid()
        {

            return _GroupInterfacesImplementaion.IsValid();
        }


    }
}
