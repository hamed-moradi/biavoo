using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_business_getById]")]
    public class Business_GetById_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [ReturnParameter]
        public byte StatusCode { get; set; }
    }

    [Schema("[dbo].[api_business_getPaging]")]
    public class Business_GetPaging_Schema: Paging_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public DateTime? @FromDate { get; set; }
        [InputParameter]
        public DateTime? @ToDate { get; set; }

        [ReturnParameter]
        public byte StatusCode { get; set; }
    }
}