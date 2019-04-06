using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("module")]
    public partial class ModuleReference: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string HttpMethod { get; set; }
        public byte? Category { get; set; }
        public byte? Priority { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class ModuleReference {
        [NotMapped]
        public string ParentTitle { get; set; }
    }
}