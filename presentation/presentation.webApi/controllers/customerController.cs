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
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using Serilog;
using shared.resource;

namespace presentation.webApi.controllers {
    public class CustomerController: BaseController {
        #region Constructor
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }
        #endregion

        [ArgumentBinding, HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery]CustomerGetByIdBindingModel collection) {
            try {
                var model = _mapper.Map<GetByIdSchema>(collection);
                var result = await _customerService.GetByIdAsync(model);
                switch(model.StatusCode) {
                    case 200:
                        return Ok(data: _mapper.Map<CustomerGetByIdViewModel>(result));
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
