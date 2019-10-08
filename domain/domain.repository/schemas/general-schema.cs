using asset.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {
    public class Void_Schema: Header_Schema {
        [HelperParameter]
        public string EntityName { get; set; } // Keyword

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}