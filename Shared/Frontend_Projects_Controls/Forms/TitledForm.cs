using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frontend_Projects_Controls.CustomControls.Label;
using Frontend_Projects_Controls.DataTypes;

namespace Frontend_Projects_Controls.Forms
{
    public partial class TitledForm : BaseForm
    {
        public TitledForm()
        {
            InitializeComponent();
        }


        [Category("Design")]
        public Dictionary<Enums.enLanguage,string> TitleTextsDisplaies
        {
            get { return txtTitle.TextsDisplaies; }

            set
            {
                txtTitle.TextsDisplaies.Clear();

                foreach(var TextDisplay in value)
                {
                    txtTitle.TextsDisplaies.Add(TextDisplay.Key, TextDisplay.Value);
                }
            }
        }


        [Category("Design")]
        public Font TitleFont
        {
            get { return txtTitle.Font; }

            set
            {
                txtTitle.Font = value;
            }
        }

    }
}
