﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[rate]")]
    public partial class Rate_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? UserId { get; set; }
        public long? EntityId { get; set; }
        public string Entity { get; set; }
        public byte? Score { get; set; } // 0 to 9
    }

    public partial class Rate_Entity {
    }
}