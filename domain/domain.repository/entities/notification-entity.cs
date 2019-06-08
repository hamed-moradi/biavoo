using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.notification")]
    public partial class Notification_Entity: Base_Entity {
        [Key]
        public int? Id { get; set; }
        public string Body { get; set; }
        public long? UserCount { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Notification_Entity {
        [NotMapped]
        public string CreatorName { get; set; }
    }
}