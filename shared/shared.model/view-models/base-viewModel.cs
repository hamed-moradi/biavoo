using System;
using System.Net;
using System.Reflection;

namespace shared.model.viewModels {
    public interface IBase_ViewModel {
    }
    public class Base_ViewModel: IBase_ViewModel {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int? TotalPages { get; set; }
        public string Version { get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }
    }
}
