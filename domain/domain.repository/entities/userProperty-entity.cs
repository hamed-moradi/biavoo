using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.userProperty")]
    public partial class UserProperty: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? PropTypeId { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class UserProperty {
        [NotMapped]
        public virtual ICollection<Customer_Entity> Customer { get; set; }
    }
}