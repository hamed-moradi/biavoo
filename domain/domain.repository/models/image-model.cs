using System;
using System.Collections.Generic;
using System.Text;
using asset.utility;

namespace domain.repository.models {
    public class Image_Model: IBase_Model {
        public int EntityId { get; set; }
        public int ScaleId { get; set; }
        public string Entity { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
