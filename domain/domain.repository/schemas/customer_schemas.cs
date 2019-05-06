using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_customer_getById]")]
    public class Customer_GetById_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [ReturnParameter]
        public byte StatusCode { get; set; }
    }

    [Schema("[dbo].[api_customer_getPaging]")]
    public class Customer_GetPaging_Schema: Paging_Schema {
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