using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Frontend_Projects_Controls.CustomControls.Label
{
    public partial class TitleLabel : cLabel
    {
        public TitleLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private Control _currentParent;
        private int _topMargin = 10;
        private bool _isAdjusting = false;

        [Category("Layout")]
        [DefaultValue(10)]
        public int TopMargin
        {
            get => _topMargin;
            set
            {
                if (_topMargin != value)
                {
                    _topMargin = value;
                    AdjustPosition();
                }
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (_currentParent != null)
            {
                _currentParent.SizeChanged -= Parent_SizeChanged;
            }

            _currentParent = this.Parent;

            if (_currentParent != null)
            {
                _currentParent.SizeChanged += Parent_SizeChanged;
                this.SizeChanged += Label_SizeChanged;
                AdjustPosition();
            }
        }

        private void Parent_SizeChanged(object sender, EventArgs e) => AdjustPosition();
        private void Label_SizeChanged(object sender, EventArgs e) => AdjustPosition();

        private void AdjustPosition()
        {
            if (_currentParent == null || _currentParent.IsDisposed || _currentParent.Disposing)
                return;

            if (_isAdjusting)
                return;

            try
            {
                _isAdjusting = true;
                int x = (_currentParent.ClientSize.Width - this.Width) / 2;
                int y = _topMargin;
                this.Location = new Point(x, y);
            }
            finally
            {
                _isAdjusting = false;
            }
        }

       

    }
}
