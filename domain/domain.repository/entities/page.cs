
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("page")]
    public partial class Page: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public string UniqueName { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Thumbnail { get; set; }
        public string Photo { get; set; }
    }

    public partial class Page {
    }
}