using domain.office;
using domain.repository.entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace presentation.dashboard.helpers {
    public class CustomCookieAuthenticationEvents: CookieAuthenticationEvents {
        private readonly IUserRepository _userRepository;

        public CustomCookieAuthenticationEvents(IUserRepository userRepository) {
            // Get the database from registered DI services.
            _userRepository = userRepository;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context) {
            var userPrincipal = context.Principal;

            // Look for the LastChanged claim.
            var lastChanged = (from c in userPrincipal.Claims
                               where c.Type == "LastChanged"
                               select c.Value).FirstOrDefault();

            if(string.IsNullOrEmpty(lastChanged) ||
                !_userRepository.ValidateLastChanged(lastChanged)) {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }

    public static class AccountHelper {
        #region Constructor
        private static readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly IModuleReferenceContainer _moduleReferenceContainer;

        static AccountHelper() {
            _httpContextAccessor = ServiceLocator.Current.GetInstance<IHttpContextAccessor>();
            _moduleReferenceContainer = ServiceLocator.Current.GetInstance<IModuleReferenceContainer>();
        }
        #endregion

        #region Private
        private static bool CheckAccess(string path) {
            return Modules().Any(a => a.Path.ToLower().Equals(path.ToLower()));
        }



        private static void Test() {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);

            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(20) });
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
        public static IEnumerable<ModuleReference> Modules() => _moduleReferenceContainer.GetByAdminId(AdminId);

        public static bool CheckPermission(IList<ModuleReference> modules, string controller, string action, string method, int? moduleId = null, string path = "") {
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

    public class CustomPrincipal: IPrincipal {
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
