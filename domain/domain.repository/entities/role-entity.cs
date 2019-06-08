using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[role]")]
    public partial class Role_Entity: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class Role_Entity {
        [NotMapped]
        public virtual ICollection<Role2Module_Entity> Role2Modules { get; set; }
    }
}