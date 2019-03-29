using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using domain.application;
using domain.repository.schemas;
using Microsoft.AspNetCore.Mvc;
using presentation.webApi.filterAttributes;
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using Serilog;
using shared.utility._app;

namespace presentation.webApi.controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly IUserService _userService;
        public UserController(IUserService userService,
            IMapper mapper, IExceptionService exceptionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _userService = userService;
        }
        #endregion

        //[ArgumentBinding]
        [HttpGet, Route("/{id}")]
        public async Task<IActionResult> Get(int id) {
            try {
                var result = await _userService.Get(id);
                switch(1) {
                    case 1:
                        return Ok(data: _mapper.Map<IList<UserGetViewModel>>(result));
                    case 0:
                        return InternalServerError();
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                //await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        //[ArgumentBinding]
        //[Route(""), HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery]UserGetBindingModel collection) {
        //    try {
        //        var maxAccurancy = int.Parse(AppSettings.MaxAccurancy);
        //        var model = _mapper.Map<UserGetSchema>(collection);
        //        var result = await _userService.Get(model);
        //        switch(model.StatusCode) {
        //            case 1:
        //                return Ok(data: _mapper.Map<IList<UserGetViewModel>>(result));
        //            case 0:
        //                return InternalServerError();
        //        }
        //    }
        //    catch(Exception ex) {
        //        Log.Error(ex, MethodBase.GetCurrentMethod().Name);
        //        //await _exceptionService.InsertAsync(ex, URL, IP);
        //    }
        //    return InternalServerError();
        //}
    }
}
