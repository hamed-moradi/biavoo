using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_business_get]")]
    public class Business_Get_Schema: IBase_Schema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Categories { get; set; } // Comma seprated CategoryId's list
        [InputParameter]
        public double? @Latitude { get; set; }
        [InputParameter]
        public double? @Longitude { get; set; }
        [InputParameter]
        public int? @Radius { get; set; } // In meters

        [ReturnParameter]
        public short StatusCode { get; set; }
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
        public short StatusCode { get; set; }
    }
}