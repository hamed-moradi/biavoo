using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.helpers {
    public class CookieHelper {
        #region Constructor
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieHelper(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        public class SearchAttribute: Attribute, IMetadataAware {
            public SearchAttribute(GeneralEnums.SearchFieldType type = GeneralEnums.SearchFieldType.String) {
                Type = type;
            }

            public GeneralEnums.SearchFieldType Type { get; }

            public void OnMetadataCreated(ModelMetadata metadata) {
                metadata.AdditionalValues["Type"] = Type;
            }
        }
        public static void Set(string path = null) {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie == null) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if(string.IsNullOrWhiteSpace(authTicket.UserData)) return;
            var serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
            var newUser = new CustomPrincipal(authTicket.Name) {
                Id = serializeModel.Id,
                FullName = serializeModel.FullName,
                Avatar = serializeModel.Avatar,
                LastLogin = serializeModel.LastLogin,
                IP = serializeModel.IP,
                Path = path
            };
            HttpContext.Current.User = newUser;
        }
    }
}
