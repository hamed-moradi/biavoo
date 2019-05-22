using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_business_getByLocation]")]
    public class Business_GetByLocation_Schema: IBase_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Categories { get; set; } // Comma seprated CategoryId's list
        [InputParameter]
        public double? @Latitude { get; set; }
        [InputParameter]
        public double? @Longitude { get; set; }
        [InputParameter]
        public bool? @MakeItValid { get; set; }
        [InputParameter]
        public int? @Radius { get; set; } // In meters

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_business_getPaging]")]
    public class Business_GetPaging_Schema: Paging_Schema {
        [InputParameter]
        public int? @CustomerId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @BusinessCode { get; set; }
        [InputParameter]
        public string @Categories { get; set; } // Comma seprated CategoryId's list

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_business_new]")]
    public class Business_New_Schema: Header_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @BusinessCode { get; set; }
        [InputParameter]
        public string @ThumbImage { get; set; }
        [InputParameter]
        public double @Latitude { get; set; }
        [InputParameter]
        public double @Longitude { get; set; }
        [InputParameter]
        public bool? @MakeItValid { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_business_edit]")]
    public class Business_Edit_Schema: Header_Schema {
        [InputParameter]
        public int Id { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @BusinessCode { get; set; }
        [InputParameter]
        public string @Thumbnail { get; set; }
        [InputParameter]
        public double? @Latitude { get; set; }
        [InputParameter]
        public double? @Longitude { get; set; }
        [InputParameter]
        public bool? @MakeItValid { get; set; }
        [InputParameter]
        public byte? Status { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}