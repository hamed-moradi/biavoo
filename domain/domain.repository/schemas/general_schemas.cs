using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {
    public class ExecByName_Schema: IBase_Schema {
        [HelperParameter]
        public string EntityName { get; set; } // Keyword

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    public class GetById_Schema: Header_Schema {
        [InputParameter]
        public int @Id { get; set; }

        [HelperParameter]
        public string EntityName { get; set; } // Keyword
        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}