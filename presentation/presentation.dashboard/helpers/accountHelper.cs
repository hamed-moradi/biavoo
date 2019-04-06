using domain.office;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace presentation.dashboard.helpers {
    public static class AccountHelper {
        #region Constructor
        private static IHttpContextAccessor _httpContextAccessor;
        private static IModuleReferenceContainer _moduleReferenceContainer;

        static AccountHelper() {
            _httpContextAccessor = ServiceLocator.Current.GetInstance<IHttpContextAccessor>();
            _moduleReferenceContainer = ServiceLocator.Current.GetInstance<IModuleReferenceContainer>();
        }
        #endregion

        #region Private
        private static bool CheckAccess(string path) {
            return Modules().Any(a => a.Path.ToLower().Equals(path.ToLower()));
        }
        #endregion

        public static int AdminId {
            get {
                if(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) {
                    var serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>
                        (FormsAuthentication.Decrypt(_httpContextAccessor.HttpContext.Request.Cookies[CookieAuthenticationOptions].Value).UserData);
                    if(serializeModel != null) {
                        return serializeModel.Id;
                    }
                }
                return 0;
            }
        }

        [OutputCache(Duration = 10)]
        public static IEnumerable<Module> Modules() => _moduleReferenceContainer.GetByAdminId(AdminId);

        public static bool CheckPermission(IList<Module> modules, string controller, string action, string method, int? moduleId = null, string path = "") {
            try {
                if(AdminId > 0) {
                    foreach(var item in modules) {
                        //if (item.HttpMethod.ToLower().Contains(method))
                        if(moduleId != null) {
                            if(item.Id == moduleId) return true;
                        }
                        else if(!string.IsNullOrWhiteSpace(path)) {
                            if(item.Path.ToLower().Equals(path.ToLower())) return true;
                        }
                        else {
                            if(item.Path.ToLower() == $@"/{controller}/{action}")
                                return true;
                        }
                    }
                    return false;
                }
                return false;
            }
            catch(Exception ex) {
                Log.Error(ex, "");
                return false;
            }
        }

        public static bool HasAccess(string path) {
            return CheckAccess(path);
        }
        public static bool HasAccess(string action, string controller) {
            return CheckAccess($"/{controller}/{action}");
        }
    }

    public class AdminCacheModel {
        public string FullName { get; set; }
        public string Ip { get; set; }
    }

    public static class UserCacheExtensions {
        private const string CookieName = "AdminCache";

        public static void AdminCache(this HttpResponseBase response, AdminCacheModel info) {
            var json = JsonConvert.SerializeObject(info);
            json = HttpUtility.UrlEncode(json);
            var cookie = new HttpCookie(CookieName, json) { Expires = DateTime.UtcNow.AddDays(60), };
            response.SetCookie(cookie);
        }

        public static AdminCacheModel AdminCache(this HttpRequestBase request) {
            var json = "{}";
            var cookie = request.Cookies.Get(CookieName);
            if(cookie != null)
                json = cookie.Value ?? json;
            json = HttpUtility.UrlDecode(json);
            var userCache = JsonConvert.DeserializeObject<AdminCacheModel>(json);
            return userCache;
        }
    }

    internal interface ICustomPrincipal: IPrincipal {
        int Id { get; set; }
        string FullName { get; set; }
        string Avatar { get; set; }
        string LastLogin { get; set; }
        string IP { get; set; }
        string Path { get; set; }
    }

    public class CustomPrincipal: ICustomPrincipal {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string LastLogin { get; set; }
        public string IP { get; set; }
        public string Path { get; set; }
        public IIdentity Identity { get; }
        public bool IsInRole(string role) {
            return false;
        }
        public CustomPrincipal(string email) {
            Identity = new GenericIdentity(email);
        }
    }

    public class CustomPrincipalSerializeModel {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string LastLogin { get; set; }
        public string IP { get; set; }
        public string Path { get; set; }
    }
}
