using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.category")]
    public partial class Category: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte Status { get; set; }
    }

    public partial class Category {
    }
}