using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using presentation.dashboard.models;
using Serilog;
using shared.utility;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.filterAttributes {
    public class SecurityFilter: ActionFilterAttribute {
        #region Constructor
        private readonly string[] UnsafeKeywords = { "javascript", "vbscript", "shutdown", "exec", "having", "union", "select", "insert", "update", "delete", "drop", "truncate", "script" };

        public SecurityFilter() {
        }
        #endregion

        #region Private
        private void KeywordChecker(ActionExecutingContext filterContext, string text) {
            if(UnsafeKeywords.Contains(text.ToLower())) {
                Log.Information(JsonConvert.SerializeObject(new {
                    Account = filterContext.HttpContext.User.Identity.Name,
                    IP = filterContext.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Method = filterContext.Controller.ToString(),
                    Keyword = text,
                    Message = "Restricted keyword detection"
                }));
                throw new Exception("درخواست شما شامل کلمات خطرناک می باشد. آی پی شما ثبت شد!", new Exception { Source = GeneralMessage.ExceptionSource });
            }
        }
        #endregion

        public override void OnActionExecuting(ActionExecutingContext context) {
            foreach(var param in context.ActionArguments) {
                if(param.Value is string && param.Value != null) {
                    //filterContext.ActionParameters[param.Key] = new KeyValuePair<string, object>(param.Key, param.Value.ToString().CharacterNormalizer());
                    KeywordChecker(context, param.Value.ToString());
                }
                if(param.Value is BaseViewModel) {
                    var properties = param.Value.GetType().GetProperties();
                    foreach(var item in properties) {
                        if(item.PropertyType == typeof(string) && item != null) {
                            //filterContext.ActionParameters[param.Key] = new KeyValuePair<string, object>(param.Key, param.Value.ToString().CharacterNormalizer());
                            KeywordChecker(context, item.ToString());
                        }
                    }
                }
            }
        }
    }
}
