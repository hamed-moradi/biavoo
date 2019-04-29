using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public class UserSignUpBindingModel: HeaderBindingModel {
        public string Name { get; set; }
        public string Family { get; set; }
        [Phone]
        public string CellPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
    public class UserSendActivationCodeBindingModel: HeaderBindingModel {
        [Phone]
        public string CellPhone { get; set; }
    }
    public class UserGetBindingModel: BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
}
