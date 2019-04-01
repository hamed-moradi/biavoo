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
using presentation.dashboard.models;
using Serilog;

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
        public IActionResult Get() {
            try {
                var result = _adminContainer.GetAll(new Admin { });
                return View(_mapper.Map<List<AdminViewModel>>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return View();
        }
    }
}
