
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("role2Module")]
    public partial class Role2Module: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }
    }

    public partial class Role2Module {
        [ForeignKey(nameof(ModuleId))]
        public virtual ModuleReference Module { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}