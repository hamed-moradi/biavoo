using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[customer]")]
    public partial class Customer_Entity: Base_Entity {
        [ForeignKey("dbo.[user].Id")]
        public int? UserId { get; set; }
        public string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Customer_Entity {
    }
}