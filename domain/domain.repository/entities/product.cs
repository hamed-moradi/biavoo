using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("product")]
    public partial class Product: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public byte Status { get; set; }
    }

    public partial class Product {
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}