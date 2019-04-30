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
using shared.resource;
using shared.utility._app;

namespace presentation.webApi.controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IUserService _userService;
        private readonly IMapper mapperr;
        public UserController(IUserService userService, IMapper mapper) {
            _userService = userService;
            mapperr = mapper;
        }
        #endregion

        [ArgumentBinding, HttpPost, Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]UserSignUpBindingModel collection) {
            try {
                var model = _mapper.Map<UserSignUpSchema>(collection);
                await _userService.SignUpAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok();
                    case 420:
                        return BadRequest(_stringLocalizer[""]);
                    case 421:
                        return BadRequest(_stringLocalizer[""]);
                    case 422:
                        return BadRequest(_stringLocalizer[""]);
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpGet, Route("sendactivationcode")]
        public async Task<IActionResult> SendActivationCode([FromQuery]UserSendActivationCodeBindingModel collection) {
            try {
                var model = _mapper.Map<UserSendActivationCodeSchema>(collection);
                await _userService.SentActivationCodeAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok();
                    case 400:
                        return BadRequest();
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpGet, Route("get")]
        public async Task<IActionResult> Get([FromQuery]GetByIdBindingModel collection) {
            try {
                if(string.IsNullOrWhiteSpace(collection.Token)) {
                    return BadRequest(_stringLocalizer[SharedResource.TokenNotFound]);
                }
                if(string.IsNullOrWhiteSpace(collection.DeviceId)) {
                    return BadRequest(_stringLocalizer[SharedResource.DeviceIdNotFound]);
                }
                var model = mapperr.Map<GetByIdSchema>(collection);
                var result = await _userService.GetAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok(data: _mapper.Map<UserViewModel>(result));
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 401:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
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
