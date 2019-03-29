using System;

namespace domain.repository.entities
{
    public partial class Notification
    {
        public int? Id { get; set; }
        public string Body { get; set; }
        public long? UserCount { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }

    public partial class Notification
    {
        public string CreatorName { get; set; }
        public long RowsCount { get; set; }
    }
}