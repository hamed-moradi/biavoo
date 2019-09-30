using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.[changeLog]")]
    public partial class ChangeLog_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? AdminId { get; set; }
        public Guid? ActivityId { get; set; }
        public byte? ActionType { get; set; }
        public string Entity { get; set; }
        public long? EntityId { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class ChangeLog_Entity {
    }
}