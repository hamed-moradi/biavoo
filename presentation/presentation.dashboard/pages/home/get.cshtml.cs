using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.office;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using asset.model.dashboardModels;

namespace presentation.dashboard.pages.home {
    public class GetModel: PageModel {
        #region Constructor
        private readonly IUser_Container _userContainer;
        public GetModel(IUser_Container userContainer) {
            _userContainer = userContainer;
        }
        #endregion
        //public void OnGet() {
        //}
        public async Task OnGetAsync() {
            var result = await _userContainer.SingleAsync<User_DashboardModel>(1);
        }
    }
}