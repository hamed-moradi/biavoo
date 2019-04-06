using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("notification")]
    public partial class Notification: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public string Body { get; set; }
        public long? UserCount { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Notification {
        [NotMapped]
        public string CreatorName { get; set; }
    }
}