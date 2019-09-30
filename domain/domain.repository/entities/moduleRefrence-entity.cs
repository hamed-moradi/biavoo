using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.moduleReference")]
    public partial class ModuleReference_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string HttpMethod { get; set; }
        public byte? Category { get; set; }
        public byte? Priority { get; set; }
        public DateTime? CreatedAt { get; set; }
        public new byte? Status { get; set; }
    }

    public partial class ModuleReference_Entity {
        [NotMapped]
        public string ParentTitle { get; set; }
    }
}