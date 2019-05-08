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
using shared.utility._app;
using shared.utility.infrastructure;

namespace presentation.webApi.controllers {
    public class SendMessageQueueController: BaseController {
        #region Constructor
        private readonly IEmailService _emailService;
        public SendMessageQueueController(IEmailService emailService) {
            _emailService = emailService;
        }
        #endregion

        [ArgumentBinding, HttpGet, Route("dequeue")]
        public async Task<IActionResult> Dequeue([FromQuery]SendMessageQueue_GetPaging_BindingModel collection) {
            if(collection.Token != AppSettings.SystemToken || collection.DeviceId != AppSettings.SystemDeviceId) {
                return BadRequest();
            }
            try {
                var model = _mapper.Map<GetById_Schema>(collection);
                //var result = await _emailService.GetByIdAsync(model);
                //switch(model.StatusCode) {
                //    case 200:
                //        return Ok(data: _mapper.Map<SendQueueGetByIdViewModel>(result));
                //    case 400:
                //        return BadRequest(_stringLocalizer[SharedResource.AuthenticationFailed]);
                //    default:
                //        return InternalServerError();
                //}
            }
            catch(Exception ex) {
                Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                await _exceptionService.InsertAsync(ex, URL, IP);
            }
            return InternalServerError();
        }
    }
}
