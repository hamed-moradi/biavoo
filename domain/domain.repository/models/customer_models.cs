using System;
using System.Collections.Generic;
using System.Text;
using shared.utility;

namespace domain.repository.models {
    public class Customer_GetById_Model: IBase_Model {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }
}
