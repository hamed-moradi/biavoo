using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.user2Notification")]
    public partial class User2Notification_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? UserId { get; set; }
        public int? NotificationId { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? SeenAt { get; set; }
        public DateTime? SentAt { get; set; }
    }

    public partial class User2Notification_Entity {
        //[RelatedField(nameof(User), nameof(User.CellPhone), nameof(UserId), true)]
        //public string UserName { get; set; }
    }
}