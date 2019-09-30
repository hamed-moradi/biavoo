using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[historyLog]")]
    public partial class HistoryLog_Entity: Base_Entity {
        [Key]
        public new long? Id { get; set; }
        public int? UserId { get; set; }
        public Guid? ActivityId { get; set; }
        public byte? ActionType { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class HistoryLog_Entity {
    }
}