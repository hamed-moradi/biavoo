using Microsoft.AspNetCore.Mvc.Filters;
using presentation.dashboard.models.bindingModels;
using System.Linq;

namespace presentation.dashboard.filterAttributes {
    public class ArgumentBinding: ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            foreach(var param in context.ActionArguments) {
                if(param.Value is IBaseBindingModel) {
                    var properties = param.Value.GetType().GetProperties();
                    foreach(var item in properties) {
                        if(!string.IsNullOrWhiteSpace(item.Name)) {
                            switch(item.Name.ToLower()) {
                                case "applicationownerkey":
                                var ownerkey = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("ownerkey"));
                                if(ownerkey.Value.Any())
                                    item.SetValue(param.Value, ownerkey.Value[0]);
                                break;
                                case "dataownercenterkey":
                                var dataOwnerCenterKey = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("dataownercenterkey"));
                                if(dataOwnerCenterKey.Value.Any())
                                    item.SetValue(param.Value, dataOwnerCenterKey.Value[0]);
                                break;
                                case "dataownerkey":
                                var dataOwnerKey = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("dataownerkey"));
                                if(dataOwnerKey.Value.Any())
                                    item.SetValue(param.Value, dataOwnerKey.Value[0]);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
