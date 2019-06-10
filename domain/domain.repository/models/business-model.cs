using System;
using System.Collections.Generic;
using System.Text;
using shared.utility;

namespace domain.repository.models {
    public class Business_Model: Paging_Model {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string BusinessCode { get; set; }
        public string ThumbImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public virtual Customer_Model Customer { get; set; }
    }
}
