using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public class UserSignUpBindingModel: HeaderBindingModel {
        public string Name { get; set; }
        public string Family { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
    public class UserGetBindingModel: BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
}
