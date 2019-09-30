using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[businessCategory]")]
    public partial class BusinessCategory_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbImage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public new byte? Status { get; set; }
    }

    public partial class BusinessCategory_Entity {
    }
}