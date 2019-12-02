using System;
using System.Net;
using System.Reflection;

namespace asset.model.dashboardModels {
    public interface IBase_DashboardModel { }
    public abstract class Base_DashboardModel: IBase_DashboardModel {
        public virtual int Id { get; set; }
    }
    public class DashboardModel: Base_DashboardModel {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int? TotalPages { get; set; }
        public string Version { get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }
    }
}
