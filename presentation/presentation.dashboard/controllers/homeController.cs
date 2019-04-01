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
    public class HomeController: BaseController {
        #region Constructor
        public HomeController() {
        }
        #endregion

        [HttpGet]
        public IActionResult Get() {
            return View();
        }
    }
}
