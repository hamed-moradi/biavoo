using System;

namespace domain.repository.entities {
    public class SentReceivedSMS {
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsSent { get; set; }
        public int? RowNumber { get; set; }
        public string MSISDN { get; set; }
        public long RowsCount { get; set; }
    }
}
