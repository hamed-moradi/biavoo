using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using asset.utility._app;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentation.dashboard.pages {
    public class BasePageModel: PageModel {
        #region Constructor
        protected readonly IMapper _mapper;
        protected readonly IStringLocalizer<BasePageModel> _stringLocalizer;
        //protected string IP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        //protected string URL { get { return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}"; } }
        protected IList<ImageFormat> ImageFormats { get { return new List<ImageFormat> { ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Tiff, ImageFormat.Png }; } }
        //protected string[] ImageExtensions { get { return new string[] { ".jpg", ".jpeg", ".png", ".tif", ".bmp", ".gif" }; } }
        public BasePageModel() {
            _mapper = ServiceLocator.Current.GetInstance<IMapper>();
            _stringLocalizer = ServiceLocator.Current.GetInstance<IStringLocalizer<BasePageModel>>();
        }
        #endregion
    }
}
