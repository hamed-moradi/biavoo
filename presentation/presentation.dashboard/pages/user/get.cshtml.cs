using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using domain.office;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Serilog;

namespace presentation.dashboard.pages.user {
    public class GetModel: PageModel {
        #region Constructor
        protected readonly IMapper _mapper;
        protected readonly IStringLocalizer<GetModel> _stringLocalizer;
        private readonly IUser_Container _userContainer;
        public GetModel(IUser_Container userContainer) {
            _userContainer = userContainer;
        }
        #endregion

        //[HttpGet, Route("{id}")]
        //public async Task<IActionResult> FindSingleAsync([FromRoute]int id) {
        //    try {
        //        var result = await _userContainer.FindSingleAsync(id);
        //        return View(_mapper.Map<User_DashboardModel>(result));
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> FindAllAsync([FromRoute]User_ViewModel collection) {
        //    try {
        //        var model = _mapper.Map<User_Entity>(collection);
        //        var response = await _userContainer.GetPagingAsync(model);
        //        return View(response);
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAsync([FromBody]User_ViewModel collection) {
        //    try {
        //        var model = _mapper.Map<User_Entity>(collection);
        //        var response = await _userContainer.AddAsync(model);
        //        return View(response);
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateAsync([FromBody]User_ViewModel collection) {
        //    try {
        //        var model = _mapper.Map<User_Entity>(collection);
        //        var response = await _userContainer.UpdateAsync(model);
        //        return View(response);
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> RemoveAsync([FromBody]User_ViewModel collection) {
        //    try {
        //        var model = _mapper.Map<User_Entity>(collection);
        //        var response = await _userContainer.RemoveAsync(model);
        //        return View(response);
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //    }
        //    return View();
        //}
        public async Task OnGetAsync(int id) {
            try {
                var result = await _userContainer.FindSingleAsync(id);
                //return View(_mapper.Map<User_DashboardModel>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}