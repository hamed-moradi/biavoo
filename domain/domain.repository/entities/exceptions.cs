using System;

namespace domain.repository.entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Exception")]
    public partial class Exceptions
    {
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

    public partial class Exceptions
    {
        public long RowsCount { get; set; }
    }

}