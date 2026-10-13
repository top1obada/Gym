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
using Frontend_Projects_Controls.Interfaces.Valid;

namespace Frontend_Projects_Controls.CustomControls.Textbox
{
    public partial class cDisplayTextbox : TextBox,iLanguage,iValid
    {
        public cDisplayTextbox()
        {
            InitializeComponent();

            TextsDisplays = new Dictionary<Enums.enLanguage, string>();

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (IsEmpty)
            {

                Clear();

                ForeColor = Color.Black;

            }

        }


        private void _SetDisplayText()
        {
            TextsDisplays.TryGetValue(_Language, out var DisplayText);

            if (string.IsNullOrWhiteSpace(DisplayText)) return;

            RightToLeft = _Language == Enums.enLanguage.eArabic ? RightToLeft.Yes : RightToLeft.No;

            TextAlign = _Language == Enums.enLanguage.eArabic ? HorizontalAlignment.Right : HorizontalAlignment.Left;

            ForeColor = Color.Gray;

            _IsShowingPlaceHolder = true;

            Text = DisplayText;

            
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (IsEmpty) _SetDisplayText();
            

        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            IsEmpty = _IsShowingPlaceHolder || string.IsNullOrWhiteSpace(Text);

            _IsShowingPlaceHolder = false;

        }

        /// <summary>
        /// Populate this before setting <see cref="Language"/>, otherwise the placeholder text won't display.
        /// </summary>
        public readonly Dictionary<Enums.enLanguage, string> TextsDisplays;

        public bool Required { get; set; } = true;

        private bool _IsShowingPlaceHolder = false;
        public bool IsEmpty { get; private set; } = true;


        private Enums.enLanguage _Language = Enums.enLanguage.eEnglish;

        public virtual Enums.enLanguage Language
        {
            get { return _Language; }

            set
            {
                _Language = value;

                if (IsEmpty) _SetDisplayText();
            }
        }


        public virtual bool IsValid()
        {

            return !Required || (!IsEmpty);

        }


        



    }



}
