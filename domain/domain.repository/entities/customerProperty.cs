using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {
    [Table("customerPropert")]
    public partial class CustomerPropert: BaseEntity {
        [Key]
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? PropTypeId { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class CustomerPropert {
        [NotMapped]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}