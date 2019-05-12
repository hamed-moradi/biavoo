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
using Microsoft.Extensions.Localization;
using presentation.webApi.filterAttributes;
using shared.model.bindingModels;
using shared.model.viewModels;
using Serilog;
using shared.resource;

namespace presentation.webApi.controllers {
    public class CustomerController: BaseController {
        #region Constructor
        private readonly IUser_Service _userService;
        private readonly ICustomer_Service _customerService;
        public CustomerController(IUser_Service userService,ICustomer_Service customerService) {
            _userService = userService;
            _customerService = customerService;
        }
        #endregion

        [ArgumentBinding, HttpPost, Route("signin")]
        public async Task<IActionResult> SignIn([FromBody]User_SignIn_BindingModel collection) {
            var model = _mapper.Map<User_SignIn_Schema>(collection);
            try {
                await _userService.SignInAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIdNotFound]);
                    case 405:
                        return BadRequest(_stringLocalizer[SharedResource.DeviceIsNotActive]);
                    case 410:
                        return BadRequest(_stringLocalizer[SharedResource.UserIsNotActive]);
                    case 411:
                        return BadRequest(_stringLocalizer[SharedResource.RequestForVerificationCodeFirst]);
                    case 412:
                        return BadRequest(_stringLocalizer[SharedResource.VerificationCodeHasBeenExpired]);
                    case 413:
                        return BadRequest(_stringLocalizer[SharedResource.WrongVerificationCode]);
                    case 415:
                        return BadRequest(_stringLocalizer[SharedResource.WrongPassword]);
                    case 205:
                        return Ok(HttpStatusCode.PartialContent, _stringLocalizer[SharedResource.GoToStepTwo]);
                    case 200:
                        return Ok(data: model.Token);
                }
            }
            catch(Exception ex) {
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            finally {
                Log.Information($"DeviceId: '{model.DeviceId}' tried to signing in, result: '{model.StatusCode}'.");
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpPost, Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]Customer_SignUp_BindingModel collection) {
            if(string.IsNullOrWhiteSpace(collection.CellPhone) && string.IsNullOrWhiteSpace(collection.Email)) {
                return BadRequest(_stringLocalizer[SharedResource.DefectiveEntry]);
            }
            try {
                var model = _mapper.Map<Customer_SignUp_Schema>(collection);
                var user = await _customerService.SignUpAsync(model);
                switch(model.StatusCode) {
                    case 420:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveEntry]);
                    case 421:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveCellPhone]);
                    case 422:
                        return BadRequest(_stringLocalizer[SharedResource.DefectiveEmail]);
                    case 200:
                        return Ok(data: new { model.Token, user });
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }

        [ArgumentBinding, HttpGet, Route("get")]
        public async Task<IActionResult> Get([FromQuery]Customer_GetById_BindingModel collection) {
            try {
                var model = _mapper.Map<GetById_Schema>(collection);
                var result = await _customerService.GetByIdAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok(data: _mapper.Map<Customer_GetById_ViewModel>(result));
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    default:
                        return InternalServerError();
                }
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}
