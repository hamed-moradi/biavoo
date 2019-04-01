using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("admin")]
    public partial class Admin: BaseEntity {
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public byte? Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Admin {
        [NotMapped]
        public string FullName {
            get {
                var nickName = $"{Name} {Family}".Trim();
                if(nickName == string.Empty) nickName = CellPhone;
                if(nickName == string.Empty) nickName = Email;
                if(nickName == string.Empty) nickName = Username;
                return nickName;
            }
        }
        [NotMapped]
        public virtual Role Role { get; set; }
    }
}