using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[productProperty]")]
    public partial class ProductProperty_Entity: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? TypeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class ProductProperty_Entity {
        [ForeignKey(nameof(ProductId))]
        public virtual Product_Entity Product { get; set; }
        //[ForeignKey(nameof(TypeId))]
        //public virtual Business_Entity Business { get; set; }
    }
}