using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.userProperty")]
    public partial class UserProperty_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? UserId { get; set; }
        public int? PropTypeId { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class UserProperty_Entity {
        [NotMapped]
        public virtual User_Entity User { get; set; }
    }
}