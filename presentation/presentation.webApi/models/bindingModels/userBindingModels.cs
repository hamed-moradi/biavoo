using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public class User_SignUp_BindingModel: Header_BindingModel {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [Phone]
        public string CellPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
    public class ChangeMe_BindingModel: FullHeader_BindingModel {
        [Phone]
        public string CellPhone { get; set; }
    }
    public class User_Get_BindingModel: Paging_BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
    public class User_TwoFactorAuthentication_BindingModel: FullHeader_BindingModel {
        [Required]
        public int VerificationCode { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
