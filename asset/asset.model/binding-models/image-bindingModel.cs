﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asset.model.bindingModels {
    public class Image_BindingModel: IBase_BindingModel {
        public int? ScaleId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
