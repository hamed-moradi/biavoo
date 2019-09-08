using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation.desktopApp.helper {
    public class MaskedComboBox: ComboBox {
        #region ctor
        private readonly MaskedTextBox _maskedTextBox;
        public MaskedComboBox() {
            _maskedTextBox = new MaskedTextBox {
                Width = Width - 17,
                Mask = "###.###.###.###"
            };
            Controls.Add(_maskedTextBox);
            SelectedIndexChanged += (sender, e) => { _maskedTextBox.Focus(); _maskedTextBox.SelectAll(); };
        }
        #endregion
        public override string Text {
            get {
                return _maskedTextBox.Text;
            }
            set {
                _maskedTextBox.Text = value;
            }
        }
    }
}
