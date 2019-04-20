using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using domain.application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentation.webApi.filterAttributes;
using presentation.webApi.models.viewModels;
using shared.utility;
using shared.utility._app;

namespace presentation.webApi.controllers {
    [SecurityFilter, Route("[controller]")]
    public class BaseController: Controller {
        #region Constructor
        protected readonly IMapper _mapper;
        protected readonly IExceptionService _exceptionService;
        protected readonly IStringLocalizer<BaseController> _stringLocalizer;
        protected string IP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        protected string URL { get { return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}"; } }
        protected IList<ImageFormat> ImageFormats { get { return new List<ImageFormat> { ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Png }; } }
        //protected string[] ImageExtensions { get { return new string[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp", ".gif" }; } }

        public BaseController() {
            _mapper = ServiceLocator.Current.GetInstance<IMapper>();
            _exceptionService = ServiceLocator.Current.GetInstance<IExceptionService>();
            _stringLocalizer = ServiceLocator.Current.GetInstance<IStringLocalizer<BaseController>>();
        }
        #endregion

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Ok(HttpStatusCode status = HttpStatusCode.OK, string message = GeneralMessage.OK, object data = null, int? totalPages = null) {
            return Json(new BaseViewModel { Status = status, Message = message, Data = data, TotalPages = totalPages });
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult BadRequest(string message) {
            return Json(new BaseViewModel { Status = HttpStatusCode.BadRequest, Message = message });
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult InternalServerError(string message = GeneralMessage.InternalServerError) {
            return Json(new BaseViewModel { Status = HttpStatusCode.InternalServerError, Message = message });
        }
    }
}