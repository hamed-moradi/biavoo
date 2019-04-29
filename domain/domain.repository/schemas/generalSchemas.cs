using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {
    public class ExecByNameSchema: IBaseSchema {
        [HelperParameter]
        public string EntityName { get; set; } // Keyword
        [ReturnParameter]
        public int StatusCode { get; set; }
    }
    public class GetByIdSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [HelperParameter]
        public string EntityName { get; set; } // Keyword
        [ReturnParameter]
        public int StatusCode { get; set; }
    }
}