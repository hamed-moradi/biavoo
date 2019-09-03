using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation.desktopApp {
    public class Startup: DbContext {
        public Startup() { //: base("Name=ConnectionString") 
            new MainForm().Hide();
        }
        public static void Init() {
        }
    }
}
