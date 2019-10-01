using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Spatial;

namespace domain.repository.entities {
    [Table("dbo.[business]")]
    public partial class Business_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public int? CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BusinessCode { get; set; }
        public string Thumbnail { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public Geography Point { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public new byte? Status { get; set; }
    }

    public partial class Business_Entity {
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer_Entity Customer { get; set; }
    }
}