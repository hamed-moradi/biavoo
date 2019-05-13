using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.model.viewModels {
    public class Business_ViewModel: IBaseViewModel {
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public SqlGeography Point { get; set; }
    }
}
