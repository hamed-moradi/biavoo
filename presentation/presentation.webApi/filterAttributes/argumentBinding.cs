using Microsoft.AspNetCore.Mvc.Filters;
using presentation.webApi.models.bindingModels;
using System.Linq;

namespace presentation.webApi.filterAttributes {
    public class ArgumentBinding: ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            foreach(var param in context.ActionArguments) {
                if(param.Value is IBaseBindingModel) {
                    var properties = param.Value.GetType().GetProperties();
                    foreach(var item in properties) {
                        if(!string.IsNullOrWhiteSpace(item.Name)) {
                            switch(item.Name.ToLower()) {
                                case "token":
                                    var ownerkey = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("token"));
                                    if(ownerkey.Value.Any())
                                        item.SetValue(param.Value, ownerkey.Value[0]);
                                    break;
                                case "deviceid":
                                    var dataOwnerCenterKey = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("deviceid"));
                                    if(dataOwnerCenterKey.Value.Any())
                                        item.SetValue(param.Value, dataOwnerCenterKey.Value[0]);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
