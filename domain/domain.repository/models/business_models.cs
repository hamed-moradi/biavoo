﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Types;
using shared.utility;

namespace domain.repository.models {
    public class Business_Model: IBase_Model {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string BusinessCode { get; set; }
        public string ThumbImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public SqlGeography Point { get; set; }
        //public virtual Customer_Model Customer { get; set; }
    }
}
