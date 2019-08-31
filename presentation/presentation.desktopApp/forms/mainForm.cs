using domain.office.containers;
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
        public MainForm() {
            InitializeComponent();

            // todo: read from resources
            var toolStripExit = new ToolStripMenuItem {
                Text = "Exit"
            };

            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip = new ContextMenuStrip();
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.SuspendLayout();
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripExit });
            NotifyIconHandler.Instance.NotifyIcon.ContextMenuStrip.ResumeLayout(false);

            FormClosed += MainForm_FormClosed;
            toolStripExit.Click += new EventHandler(ToolStripExit_Click);
            NotifyIconHandler.Instance.NotifyIcon.Click += NotifyIcon_Click;
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
    }
}
