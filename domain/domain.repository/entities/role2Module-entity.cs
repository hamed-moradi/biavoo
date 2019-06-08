
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.role2Module")]
    public partial class Role2Module_Entity: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }
    }

    public partial class Role2Module_Entity {
        [ForeignKey(nameof(ModuleId))]
        public virtual ModuleReference_Entity Module { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role_Entity Role { get; set; }
    }
}