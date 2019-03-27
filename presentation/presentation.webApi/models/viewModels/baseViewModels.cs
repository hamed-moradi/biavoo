using System;
using System.Net;
using System.Reflection;

namespace presentation.webApi.models.viewModels {
    public interface IBaseViewModel {
    }
    public class BaseViewModel {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int? TotalPages { get; set; }
        public string Version { get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }
    }
}
