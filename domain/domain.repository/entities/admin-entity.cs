using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[admin]")]
    public partial class Admin_Entity: Base_Entity {
        [Key]
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
        public DateTime? LastLoggedin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Admin_Entity {
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
        [ForeignKey(nameof(RoleId))]
        public virtual Role_Entity Role { get; set; }
    }
}