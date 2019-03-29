
namespace domain.repository.entities {
    public partial class Module {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public string HttpMethod { get; set; }
        public byte? Category { get; set; }
        public byte? Priority { get; set; }
    }

    public partial class Module {
        public string ParentTitle { get; set; }
    }
}