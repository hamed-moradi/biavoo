using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.session")]
    public partial class Session: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Token { get; set; }
        public string DeviceId { get; set; }
        public string IP { get; set; }
        public string OS { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string Browser { get; set; }
        public string TimeZone { get; set; }
        public string Language { get; set; }
        public string FCM { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? Status { get; set; }
    }

    public partial class Session {
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}