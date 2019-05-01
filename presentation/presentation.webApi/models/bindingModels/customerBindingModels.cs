using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.bindingModels {
    public class CustomerGetByIdBindingModel: FullHeaderBindingModel {
        public int Id { get; set; }
    }
}
