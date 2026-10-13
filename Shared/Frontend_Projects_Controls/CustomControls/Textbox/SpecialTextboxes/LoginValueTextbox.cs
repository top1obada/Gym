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
    public sealed partial class LoginValueTextbox : cDisplayTextbox
    {

        public enum enLoginData { eUserName = 1, eEmail = 2, ePhoneNumber = 3 }
        public LoginValueTextbox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private enLoginData _LoginData = enLoginData.eUserName;

        public enLoginData LoginData
        {
            get { return _LoginData; }

            set
            {
                _LoginData = value;

                TextsDisplays.Clear();

                switch (_LoginData)
                {
                    case enLoginData.eUserName:
                        {
                            TextsDisplays.Add(Enums.enLanguage.eEnglish, "User Name");
                            TextsDisplays.Add(Enums.enLanguage.eArabic, "اسم المستخدم");
                            break;
                        }
                    case enLoginData.eEmail:
                        {
                            TextsDisplays.Add(Enums.enLanguage.eEnglish, "Email");
                            TextsDisplays.Add(Enums.enLanguage.eArabic, "البريد الإلكتروني");
                            break;
                        }
                    case enLoginData.ePhoneNumber:
                        {
                            TextsDisplays.Add(Enums.enLanguage.eEnglish, "Phone Number");
                            TextsDisplays.Add(Enums.enLanguage.eArabic, "رقم الهاتف");
                            break;
                        }
                }

                Language = Language;
            }
        }
    }
}