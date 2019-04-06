using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("customer")]
    public partial class Customer: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Customer {
        [NotMapped]
        public string FullName { get { return $"{Name} {Family}".Trim(); } }
    }
}