using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("role")]
    public partial class Role: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class Role {
        [NotMapped]
        public virtual ICollection<Role2Module> Role2Modules { get; set; }
    }
}