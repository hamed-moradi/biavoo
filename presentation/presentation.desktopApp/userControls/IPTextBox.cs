using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using presentation.desktopApp.helper;

namespace IPTextBox {
    public partial class IPTextBox: UserControl {
        public IPTextBox() {
            InitializeComponent();

            tbSegment1.KeyDown += TBSegment_KeyDown;
            tbSegment2.KeyDown += TBSegment_KeyDown;
            tbSegment3.KeyDown += TBSegment_KeyDown;
            tbSegment4.KeyDown += TBSegment_KeyDown;

            tbSegment1.KeyPress += TBSegment_KeyPress;
            tbSegment2.KeyPress += TBSegment_KeyPress;
            tbSegment3.KeyPress += TBSegment_KeyPress;
            tbSegment4.KeyPress += TBSegment_KeyPress;
        }

        private void TBSegment_KeyDown(object sender, KeyEventArgs e) {
            var textBox = (TextBox)sender;
            var selectedTag = textBox.Tag.ToInt();

            if(e.KeyCode == Keys.Left) {
                if(selectedTag > 1 && textBox.SelectionStart == 0) {
                    SendKeys.Send("+{TAB}");
                }
            }
            else if(e.KeyCode == Keys.Right) {
                if(selectedTag < 4 && textBox.SelectionStart == textBox.TextLength) {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void TBSegment_KeyPress(object sender, KeyPressEventArgs e) {
            var keyCode = e.KeyChar.ToKeyCode();
            var textBox = (TextBox)sender;
            var selectedTag = textBox.Tag.ToInt();

            if((keyCode >= Keys.D0 && keyCode <= Keys.D9) || (keyCode >= Keys.NumPad0 && keyCode <= Keys.NumPad9)) {
                if(textBox.TextLength == 3) {
                    e.Handled = true;
                    return;
                }
                if(selectedTag < 4 && textBox.TextLength >= 2) {
                    SendKeys.Send("{TAB}");
                }
                var isValidNumber = int.TryParse($"{textBox.Text}{e.KeyChar}", out int segment);
                if(isValidNumber) {
                    if(segment > 255) {
                        textBox.Text = "255";
                        textBox.SelectionStart = 3;
                    }
                    else {
                        e.Handled = true;
                        textBox.Text = segment.ToString();
                        textBox.SelectionStart = textBox.TextLength;
                    }
                }
            }
            else if(keyCode == Keys.Back) {
                if(selectedTag > 1 && textBox.SelectionStart <= 0) {
                    SendKeys.Send("+{TAB}");
                }
            }
            else if(keyCode == Keys.Decimal || keyCode == Keys.OemPeriod) {
                e.Handled = true;
                if(selectedTag < 4 && textBox.TextLength > 0) {
                    SendKeys.Send("{TAB}");
                }
            }
            else {
                e.Handled = true;
            }
        }
    }
}
