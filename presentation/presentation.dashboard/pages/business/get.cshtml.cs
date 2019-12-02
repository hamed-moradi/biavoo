using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentation.dashboard.pages;

namespace presentation.dashboard.views.business {
    public class GetModel: BasePageModel {
        public void OnGet() {
        }

        //#region Constructor
        //private readonly IBusiness_Container _businessContainer;
        //public BusinessController(IBusiness_Container businessContainer) {
        //    _businessContainer = businessContainer;
        //}
        //#endregion

        //[Route("{id}")]
        //public async Task<IActionResult> Get([FromQuery]int id) {
        //    try {
        //        var result = await _businessContainer.GetByIdAsync(id);
        //        return View(_mapper.Map<Business_DashboardModel>(result));
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}
    }
}
