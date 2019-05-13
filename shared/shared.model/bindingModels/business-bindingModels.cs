using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace shared.model.bindingModels {
    public class Business_Get_BindingModel: Header_BindingModel {
        public string Title { get; set; }
        public string Categories { get; set; } // Comma seprated CategoryId's list
        public double? @Latitude { get; set; }
        public double? @Longitude { get; set; }
        public int? Radius { get; set; } // In meters
    }
}
