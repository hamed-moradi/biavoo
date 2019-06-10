using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using domain.office;
using domain.repository.entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using shared.model.dashboard_models;

namespace presentation.dashboard.controllers {
    public class AdminController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IAdminContainer _adminContainer;
        public AdminController(IMapper mapper, IAdminContainer adminContainer) {
            _mapper = mapper;
            _adminContainer = adminContainer;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await _adminContainer.GetAllAsync(new Admin_Entity { });
                return View(_mapper.Map<List<Admin_DashboardModel>>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return View();
        }
    }
}
