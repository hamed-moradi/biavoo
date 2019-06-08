using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[product]")]
    public partial class Product_Entity: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public byte Status { get; set; }
    }

    public partial class Product_Entity {
        [ForeignKey(nameof(CategoryId))]
        public virtual Category_Entity Category { get; set; }
    }
}