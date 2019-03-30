using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace domain.repository.entities {
    public partial class CustomerPropert {
        [Key]
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? PropTypeId { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public partial class CustomerPropert {
        public virtual ICollection<Customer> Customer { get; set; }
    }
}