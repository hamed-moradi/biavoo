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
    public class AccountController: BaseController {
        #region Constructor
        private readonly IAdminContainer _adminContainer;
        public AccountController(IAdminContainer adminContainer) {
            _adminContainer = adminContainer;
        }
        #endregion

        [HttpGet]
        public IActionResult Get() {
            return View();
        }
    }
}
