using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace presentation.dashboard.controllers {
    public class BaseController: Controller {
        protected string IP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        protected string URL { get { return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}"; } }
        protected IList<ImageFormat> ImageFormats { get { return new List<ImageFormat> { ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Png }; } }
        //protected string[] ImageExtensions { get { return new string[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp", ".gif" }; } }
    }
}