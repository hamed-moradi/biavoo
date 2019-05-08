using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using domain.application;
using domain.repository.schemas;
using Microsoft.AspNetCore.Mvc;
using presentation.webApi.filterAttributes;
using shared.model.bindingModels;
using shared.model.viewModels;
using Serilog;
using shared.resource;
using shared.utility.infrastructure;

namespace presentation.webApi.controllers {
    public class UserController: BaseController {
        #region Constructor
        private readonly IUser_Service _userService;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IEmailService _emailService;
        private readonly ISMSService _smsService;
        public UserController(IUser_Service userService, IRandomGenerator randomGenerator, IEmailService emailService, ISMSService smsService) {
            _userService = userService;
            _randomGenerator = randomGenerator;
            _emailService = emailService;
            _smsService = smsService;
        }
        #endregion

        [ArgumentBinding, HttpPost, Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]User_SignUp_BindingModel collection) {
            if(string.IsNullOrWhiteSpace(collection.CellPhone) && string.IsNullOrWhiteSpace(collection.Email)) {
                return BadRequest(_stringLocalizer[SharedResource.DefectiveEntry]);
            }
            try {
                var model = _mapper.Map<User_SignUp_Schema>(collection);
                await _userService.SignUpAsync(model);
                switch(model.StatusCode) {
                    case 420:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveEntry]);
                    case 421:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveCellPhone]);
                    case 422:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveEmail]);
                    case 500:
                        return InternalServerError();
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

        [ArgumentBinding, HttpGet, Route("sendverificationcode")]
        public async Task<IActionResult> SendVerificationCode(User_Verify_BindingModel collection) {
            ValidateHeader(collection);
            try {
                var model = _mapper.Map<User_SetVerificationCode_Schema>(collection);
                model.VerificationCode = _randomGenerator.Create("****");
                await _userService.SetVerificationCodeAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIsNotActive]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 416:
                        return BadRequest(_stringLocalizer["u must register a cell phone first"]);
                    case 417:
                        return BadRequest(_stringLocalizer["CellPhone does not match"]);
                    case 418:
                        return BadRequest(_stringLocalizer["u must register an email first"]);
                    case 419:
                        return BadRequest(_stringLocalizer["Email does not match"]);
                    case 200: {
                        if(!string.IsNullOrWhiteSpace(model.CellPhone)) {
                            _smsService.Send(model.CellPhone, $"{_stringLocalizer["This is your verification code"]} {model.VerificationCode}");
                        }
                        if(!string.IsNullOrWhiteSpace(model.Email)) {
                            _emailService.Send(model.CellPhone, _stringLocalizer["Verification code"],
                                $"{_stringLocalizer["This is your verification code"]} {model.VerificationCode}");
                        }
                        return Ok();
                    }
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpGet, Route("verify")]
        public async Task<IActionResult> Verify(User_Verify_BindingModel collection) {
            ValidateHeader(collection);
            try {
                var model = _mapper.Map<User_Verify_Schema>(collection);
                await _userService.VerifyAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIsNotActive]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 416:
                        return BadRequest(_stringLocalizer["u must register a cell phone first"]);
                    case 417:
                        return BadRequest(_stringLocalizer["CellPhone does not match"]);
                    case 418:
                        return BadRequest(_stringLocalizer["u must register an email first"]);
                    case 419:
                        return BadRequest(_stringLocalizer["Email does not match"]);
                    case 205:
                        return Ok(_stringLocalizer["u'r cell phone is already active"]);
                    case 210:
                        return Ok(_stringLocalizer["u'r email is already active"]);
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
            ValidateHeader(collection);
            try {
                var model = _mapper.Map<GetById_Schema>(collection);
                //model.EntityName = "[user]";
                var result = await _userService.GetAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIsNotActive]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 200:
                        return Ok(data: _mapper.Map<User_ViewModel>(result));
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
            ValidateHeader(collection);
            if(collection.Password.Length < 6) {
                return BadRequest(_stringLocalizer["your password doesn't meet the legal length"]);
            }
            try {
                var model = _mapper.Map<User_EnableTwoFactorAuthentication_Schema>(collection);
                await _userService.EnableTwoFactorAuthentication(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIsNotActive]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 411:
                        return BadRequest(_stringLocalizer["You must request for a verification code first"]);
                    case 412:
                        return BadRequest(_stringLocalizer["Your code has expired"]);
                    case 413:
                        return BadRequest(_stringLocalizer["Verification code is not valid"]);
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
            ValidateHeader(collection);
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
