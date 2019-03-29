using System;

namespace domain.repository.entities
{
    public partial class ChangeLog
    {
        public int? Id { get; set; }
        public int AdminId { get; set; }
        public byte ActionType { get; set; }
        public string Entity { get; set; }
        public long EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public partial class ChangeLog
    {
        public long RowsCount { get; set; }

    }
}