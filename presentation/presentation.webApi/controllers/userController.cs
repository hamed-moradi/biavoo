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
using shared.utility.infrastructure;

namespace presentation.webApi.controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IUser_Service _userService;
        private readonly IRandomGenerator _randomGenerator;
        public UserController(IUser_Service userService, IRandomGenerator randomGenerator) {
            _userService = userService;
            _randomGenerator = randomGenerator;
        }
        #endregion

        [ArgumentBinding, HttpPost, Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]User_SignUp_BindingModel collection) {
            try {
                var model = _mapper.Map<User_SignUp_Schema>(collection);
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

        [ArgumentBinding, HttpGet, Route("sendverificationcode")]
        public async Task<IActionResult> SendVerificationCode(FullHeader_BindingModel collection) {
            try {
                var model = _mapper.Map<User_SendVerificationCode_Schema>(collection);
                model.Number = _randomGenerator.Create("****");
                await _userService.SendVerificationCodeAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest();
                    case 200:
                        return Ok();
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpGet, Route("get")]
        public async Task<IActionResult> Get([FromQuery]GetById_BindingModel collection) {
            try {
                if(string.IsNullOrWhiteSpace(collection.Token)) {
                    return BadRequest(_stringLocalizer[SharedResource.TokenNotFound]);
                }
                if(string.IsNullOrWhiteSpace(collection.DeviceId)) {
                    return BadRequest(_stringLocalizer[SharedResource.DeviceIdNotFound]);
                }
                var model = _mapper.Map<GetById_Schema>(collection);
                var result = await _userService.GetAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok(data: _mapper.Map<User_ViewModel>(result));
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

        [ArgumentBinding, HttpPost, Route("enabletwofactorauthentication")]
        public async Task<IActionResult> EnableTwoFactorAuthentication([FromBody]User_TwoFactorAuthentication_BindingModel collection) {
            if(collection.Password.Length < 6) {
                return BadRequest(_stringLocalizer["your password doesn't meet the legal length"]);
            }
            try {
                var model = _mapper.Map<User_EnableTwoFactorAuthentication_Schema>(collection);
                await _userService.EnableTwoFactorAuthentication(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.TokenNotFound]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIdNotFound]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 430:
                        return BadRequest(_stringLocalizer["verification code is not valid"]);
                    case 431:
                        return BadRequest(_stringLocalizer["password is not valid"]);
                    case 432:
                        return BadRequest(_stringLocalizer["varsification code has been expired"]);
                    case 200:
                        return Ok();
                }
            }
            catch(Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpPost, Route("disabletwofactorauthentication")]
        public async Task<IActionResult> DisableTwoFactorAuthentication([FromBody]User_TwoFactorAuthentication_BindingModel collection) {
            try {
                var model = _mapper.Map<User_DisableTwoFactorAuthentication_Schema>(collection);
                await _userService.DisableTwoFactorAuthentication(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.TokenNotFound]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIdNotFound]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 415:
                        return BadRequest(_stringLocalizer[""]);
                    case 200:
                        return Ok();
                }
            }
            catch(Exception ex) {
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
