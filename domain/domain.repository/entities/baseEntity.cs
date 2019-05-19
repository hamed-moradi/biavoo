using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.repository.entities {
    public class BaseEntity {
        [NotMapped]
        public string OrderBy { get; set; } = "Id";
        [NotMapped]
        public string Order { get; set; } = "DESC";
        [NotMapped]
        public int Skip { get; set; } = 0;
        [NotMapped]
        public int Take { get; set; } = 10;
        [NotMapped]
        public long TotalCount { get; set; } = 0;
    }
}
