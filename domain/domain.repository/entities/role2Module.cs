
namespace domain.repository.entities {
    public partial class Role2Module {
        public int? Id { get; set; }
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }
    }

    public partial class Role2Module {

        public virtual Module Module { get; set; }
        public virtual Role Role { get; set; }
        public long RowsCount { get; set; }
    }
}