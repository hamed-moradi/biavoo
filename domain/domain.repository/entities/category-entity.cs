using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[category]")]
    public partial class Category_Entity: Base_Entity {
        public Category_Entity() { }
        [Key]
        public new int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public new byte? Status { get; set; }
    }

    public partial class Category_Entity {
    }
}