using System;
using System.Collections.Generic;
using System.Text;
using shared.utility;

namespace domain.repository.models {
    public class Comment_Model: Paging_Model {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public long EntityId { get; set; }
        public string Entity { get; set; }
        public string Body { get; set; }
    }
}
