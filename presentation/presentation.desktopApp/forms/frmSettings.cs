using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation.desktopApp.forms {
    public partial class frmSettings: Form {
        public frmSettings() {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Hide();
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        private void FrmSettings_Load(object sender, EventArgs e) {
            cmbLanguage.Items.AddRange(new object[] { "En", "Fa" });
        }
    }
}
