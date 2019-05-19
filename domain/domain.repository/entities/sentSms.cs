using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("dbo.sentSms")]
    public partial class SentSms: BaseEntity {
        [Key]
        public long? Id { get; set; }
        public string Getway { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string MSISDN { get; set; }
        public string Body { get; set; }
        public int? TraceID { get; set; }
        public string ShortCode { get; set; }
        public byte? Status { get; set; }
        public long? Correlator { get; set; }
        public int? ResponseStatusCode { get; set; }
        public string ResponseStatusDescription { get; set; }
        public string ResponseBody { get; set; }
        public string AutoMessageUniqueKey { get; set; }
        public string AutoMessageChannelKey { get; set; }
    }
    public partial class SentSms {
    }
}
