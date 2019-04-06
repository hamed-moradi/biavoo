using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("exception")]
    public partial class Exceptions: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string URL { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }
        public string IP { get; set; }
    }

    public partial class Exceptions {
    }

}