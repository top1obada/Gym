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
using Frontend_Projects_Controls.Forms;
using Gym_Backend_DTO.Login;
using GYM_Frontend_API_Connectivity.Connection.Login;
using GYM_Frontend_UI.Data.JWT_Data;

namespace GYM_Frontend_UI.Login_UI
{
    public partial class fLogin : TitledForm
    {

        private readonly acLogin _LoginService;
        public fLogin(acLogin LoginService) : base()
        {
            
            InitializeComponent();

            TitleTextsDisplaies = new Dictionary<Enums.enLanguage, string>()
            {
                [Enums.enLanguage.eEnglish] = "Login",
                [Enums.enLanguage.eArabic] = "تسجيل الدخول"
            };

            Language = Enums.enLanguage.eEnglish;

            _LoginService = LoginService;
        }

        private async void ctrlLogin1_OnLogin(string arg1, string arg2, bool arg3)
        {
            var Requirements = new clsSystemUserLoginRequirementsDTO();

            Requirements.Email = arg1;
            Requirements.Password = arg2;

            var result = await _LoginService.Login(Requirements);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                MessageBox.Show("Failed", result.ErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            clsJWTData.FillFromToken(result.Token);


        }
    }
}
