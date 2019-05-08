using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.model.bindingModels {
    public class Customer_GetById_BindingModel: FullHeader_BindingModel {
        public int Id { get; set; }
    }
}
