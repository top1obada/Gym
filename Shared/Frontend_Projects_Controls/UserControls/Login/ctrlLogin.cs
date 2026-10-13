using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend_Projects_Controls.CustomControls.Textbox.SpecialTextboxes;
using Frontend_Projects_Controls.DataTypes;

namespace Frontend_Projects_Controls.UserControls.Login
{
    public partial class ctrlLogin : ctrlBaseUserControl
    {
        public ctrlLogin()
        {
            InitializeComponent();
        }

        public event Action<string, string, bool> OnLogin;


        public LoginValueTextbox.enLoginData LoginData
        {
            get
            {
                return txtLoginData.LoginData;
            }
            set
            {
                txtLoginData.LoginData = value;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (OnLogin != null)
            {
                OnLogin.Invoke(txtLoginData.Text, txtPassword.Text, cbRememberMe.Checked);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
