using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.model.dashboardModels {
    public class Signin_DashboardModel: IBase_DashboardModel {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
}
}
