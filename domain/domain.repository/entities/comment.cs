using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.comment")]
    public partial class Comment: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public long? EntityId { get; set; }
        public string Entity { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte Status { get; set; }
    }

    public partial class Comment {
    }
}