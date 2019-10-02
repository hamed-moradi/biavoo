using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentation.dashboard.pages.admin {
    public class GetModel: PageModel {
        //#region Constructor
        //private readonly IAdmin_Container _adminContainer;
        //public AdminController(IAdmin_Container adminContainer) {
        //    _adminContainer = adminContainer;
        //}
        //#endregion

        //[HttpGet]
        //public async Task<IActionResult> Get() {
        //    try {
        //        var result = await _adminContainer.GetAllAsync(new Admin_Entity { });
        //        return View(_mapper.Map<List<Admin_DashboardModel>>(result));
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}

        public void OnGet() {

        }
        public void OnPost() {

        }
    }
}