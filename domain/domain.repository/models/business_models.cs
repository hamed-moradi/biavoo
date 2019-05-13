using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Types;
using shared.utility;

namespace domain.repository.models {
    public class Business_Model: IBase_Model {
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public SqlGeography Point { get; set; }
    }
}
