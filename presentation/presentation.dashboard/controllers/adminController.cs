using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using domain.office;
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

        [HttpGet, Route("{id}")]
        public IActionResult Get([FromQuery]int id) {
            try {
                var result = _adminContainer.Get(id);
                return View(_mapper.Map<AdminViewModel>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                //await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return View();
        }
    }
}
