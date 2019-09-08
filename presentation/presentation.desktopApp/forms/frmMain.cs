using domain.office.containers;
using presentation.desktopApp.forms;
using presentation.desktopApp.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation.desktopApp {
    public partial class MainForm: Form {
        #region ctor
        private frmSettings _frmSettings;
        public MainForm() {
            InitializeComponent();

            PreparingForm();
            EventBinder();
            SettingFormInit();
        }
        #endregion

        #region private
        private void EventBinder() {
            NotifyIconHandler.Instance.NotifyIcon.Click += NotifyIcon_Click;
            FormClosed += MainForm_FormClosed;
            cmbPreferredDNS.GotFocus += CmbPreferredDNS_GotFocus;
        }

        private void CmbPreferredDNS_GotFocus(object sender, EventArgs e) {
            cmbPreferredDNS.SelectionLength = 0;
        }

        private ToolStripItem[] SettingUpContextMenu() {
            var contextMenu = new ToolStripItem[2];

            var toolStripSettings = new ToolStripMenuItem {
                Text = Properties.Resources.Settings
            };
            toolStripSettings.Click += ToolStripSettings_Click;
            contextMenu[0] = toolStripSettings;

            var toolStripExit = new ToolStripMenuItem {
                Text = Properties.Resources.Exit
            };
            toolStripExit.Click += ToolStripExit_Click;
            contextMenu[1] = toolStripExit;

            return contextMenu;
        }
        private void PreparingForm() {
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip = new ContextMenuStrip();
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.SuspendLayout();
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.Items.AddRange(SettingUpContextMenu());
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.ResumeLayout(false);
        }
        private void ShowSettings() {
            Hide();
            SettingFormInit();
            if(_frmSettings.Visible) {
                _frmSettings.Focus();
            }
            else {
                _frmSettings.Show();
            }
        }
        private void SettingFormInit() {
            if(_frmSettings == null) {
                _frmSettings = new frmSettings();
            }
        }
        #endregion

        private void ToolStripSettings_Click(object sender, EventArgs e) {
            ShowSettings();
        }

        public void NotifyIcon_Click(object sender, EventArgs e) {
            var mouseClick = (MouseEventArgs)e;
            if(mouseClick.Button == MouseButtons.Right) {
                return;
            }
            if(Visible) {
                Hide();
            }
            else {
                int iconWidth = NotifyIconHandler.Instance.Icon.Width,
                    iconHeight = NotifyIconHandler.Instance.Icon.Height,
                    formLocationX = MousePosition.X - (Width / 2) - (iconWidth / 2),
                    formLocationY = MousePosition.Y - Height - iconHeight;

                var point = NotifyIconHandler.Instance.GetLocation(false);
                if(point.HasValue) {
                    formLocationX = point.Value.X - (Width / 2) + (iconWidth / 4);
                    formLocationY = point.Value.Y - Height - (iconHeight / 4);
                }
                SetDesktopLocation(formLocationX, formLocationY);
                Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            NotifyIconHandler.Instance.NotifyIcon.Visible = false;
        }

        private void BtnTray_Click(object sender, EventArgs e) {
            Hide();
        }

        private void ToolStripExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void BtnSettings_Click(object sender, EventArgs e) {
            ShowSettings();
        }

        private void CmbPreferredDNS_KeyUp(object sender, KeyEventArgs e) {
            var selectionStart = cmbPreferredDNS.SelectionStart;
            if(e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab &&
                e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.Home && e.KeyCode != Keys.End &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9 ||
                cmbAlternateDNS.Text.Length > 15)) {
                return;
            }
            cmbPreferredDNS.Text = IPValidator.Exec(cmbPreferredDNS.Text);
            cmbPreferredDNS.SelectionStart = selectionStart;
        }
    }
}
