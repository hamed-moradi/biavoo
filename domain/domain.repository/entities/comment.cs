﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.comment")]
    public partial class Comment: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }
        public long? EntityId { get; set; }
        public string Entity { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Comment {
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Comment Parent { get; set; }
    }
}