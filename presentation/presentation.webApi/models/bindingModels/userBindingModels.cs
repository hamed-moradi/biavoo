using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public class UserSignUpBindingModel: HeaderBindingModel {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [Phone]
        public string CellPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
    public class UserSendVerificationCodeBindingModel: FullHeaderBindingModel {
        [Phone]
        public string CellPhone { get; set; }
    }
    public class UserGetBindingModel: BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
    public class TwoFactorAuthenticationBindingModel: FullHeaderBindingModel {
        [Required]
        public int VerificationCode { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
