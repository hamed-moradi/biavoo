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
    public class BusinessController: BaseController {
        #region Constructor
        private readonly IBusiness_Service _businessService;
        public BusinessController(IBusiness_Service businessService) {
            _businessService = businessService;
        }
        #endregion
        
        [ArgumentBinding, HttpGet, Route("get")]
        public async Task<IActionResult> Get([FromQuery]Business_Get_BindingModel collection) {
            try {
                var model = _mapper.Map<Business_Get_Schema>(collection);
                var result = await _businessService.GetAsync(model);
                switch(model.StatusCode) {
                    case 400:
                        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                    case 200:
                        return Ok(data: _mapper.Map<List<Business_ViewModel>>(result));
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
