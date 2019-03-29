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
    public class UserController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IUserContainer _userContainer;
        public UserController(IMapper mapper, IUserContainer userContainer) {
            _mapper = mapper;
            _userContainer = userContainer;
        }
        #endregion

        [HttpGet, Route("{id}")]
        public IActionResult Get([FromQuery]int id) {
            try {
                var result = _userContainer.Get(id);
                return View(_mapper.Map<UserViewModel>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                //await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return View();
        }
    }
}
