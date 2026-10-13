using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend_Projects_Controls.DataTypes;
using Frontend_Projects_Controls.Interfaces.Language;
using Frontend_Projects_Controls.Interfaces.Valid;

namespace Frontend_Projects_Controls.Data
{
    public sealed class clsGroupInterfacesImplementaion
    {
        private readonly Control _control;
        public clsGroupInterfacesImplementaion(Control control)
        {
            _control = control;
        }

        private Enums.enLanguage _Language = Enums.enLanguage.eEnglish;
        public Enums.enLanguage Language
        {
            get {  return _Language; }

            set { _Language = value;

                foreach (Control child in _control.Controls) 
                {
                    if (child is iLanguage languageControl)
                    {
                        languageControl.Language = _Language;
                    }
                }
            }
        }

        public bool IsValid()
        {
            foreach (Control child in _control.Controls) 
            {
                if (child is iValid validControl && !validControl.IsValid())
                {
                    return false;
                }
            }

            return true;
        }

    }
}
