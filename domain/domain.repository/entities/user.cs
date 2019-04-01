using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("user")]
    public partial class User: BaseEntity {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActivitionCode { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string Phone { get; set; }
        public bool? PhoneVerified { get; set; }
        public string Avatar { get; set; }
        public byte? IdentityProvider { get; set; }
    }

    public partial class User {
        //public string FullName {
        //    get {
        //        var name = ($"{FirstName} {LastName}").Trim();
        //        if(string.IsNullOrWhiteSpace(name)) name = CellPhone;
        //        if(string.IsNullOrWhiteSpace(name)) name = Email;
        //        return name;
        //    }
        //}
        //[RelatedField(nameof(Admin), nameof(Admin.Username), nameof(CreatorId))]
        //public override string CreatorName { get; set; }
    }
}