using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.userPrivacy")]
    public partial class UserPrivacy_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? UserId { get; set; }
        public bool? AppearingInSearch { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class UserPrivacy_Entity {
        [NotMapped]
        public virtual User_Entity User { get; set; }
    }
}