using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.dashboard.models.bindingModels {
    public class UserGetBindingModel: BindingModel {
        public string Tilte { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
    }
}
