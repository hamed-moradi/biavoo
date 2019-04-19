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

namespace presentation.webApi.controllers {
    public class CustomerController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IExceptionService _exceptionService;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, IStringLocalizer stringLocalizer, IMapper mapper, IExceptionService exceptionService) {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _exceptionService = exceptionService;
            _customerService = customerService;
        }
        #endregion

        [ArgumentBinding, HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery]CustomerGetByIdBindingModel collection) {
            try {
                var model = _mapper.Map<CustomerGetByIdSchema>(collection);
                var result = await _customerService.GetById(model);
                return Ok(data: _mapper.Map<CustomerGetByIdViewModel>(result), message:_stringLocalizer[""]);
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}
