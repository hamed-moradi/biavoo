using System.Collections.Generic;

namespace domain.repository.entities {
    public partial class Role {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }

    public partial class Role {
        public virtual string ParentTitle { get; set; }
        public virtual IEnumerable<Role2Module> Role2Modules { get; set; }
    }
}