using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using presentation.webApi.models.bindingModels;
using presentation.webApi.models.viewModels;
using domain.utility;

namespace presentation.webApi.controllers {
    [Route("api/[controller]")]
    public class BaseController: Controller {
        #region Constructor
        protected string IP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        protected string URL { get { return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}"; } }
        protected IList<ImageFormat> ImageFormats { get { return new List<ImageFormat> { ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Png }; } }
        //protected string[] ImageExtensions { get { return new string[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp", ".gif" }; } }
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