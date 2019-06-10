﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using domain.office;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using shared.model.dashboard_models;

namespace presentation.dashboard.controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IUserContainer _userContainer;
        public UserController(IUserContainer userContainer) {
            _userContainer = userContainer;
        }
        #endregion

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([FromQuery]int id) {
            try {
                var result = await _userContainer.GetByIdAsync(id);
                return View(_mapper.Map<User_DashboardModel>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return View();
        }
    }
}
