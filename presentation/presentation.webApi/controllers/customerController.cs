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

namespace presentation.webApi.controllers {
    public class CustomerController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IExceptionService _exceptionService;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService,
            IMapper mapper, IExceptionService exceptionService) {
            _mapper = mapper;
            _exceptionService = exceptionService;
            _customerService = customerService;
        }
        #endregion

        [ArgumentBinding, HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery]CustomerGetByIdBindingModel collection) {
            try {
                var model = _mapper.Map<CustomerGetByIdSchema>(collection);
                var result = await _customerService.GetById(model);
                return Ok(_mapper.Map<CustomerGetByIdViewModel>(result));
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                //await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}
