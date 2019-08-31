using domain.office.containers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation.desktopApp {
    public class Startup {
        public static void Init() {
            new MainForm().Hide();
        }
    }
}
