using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_product_get]")]
    public class Product_Get_Schema: IBase_Schema {
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

    [Schema("[dbo].[api_product_getPaging]")]
    public class Product_GetPaging_Schema: Paging_Schema {
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
        public bool? @MakeItValid { get; set; }
        [InputParameter]
        public int? @Radius { get; set; } // In meters

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_product_new]")]
    public class Product_New_Schema: Header_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @ProductCode { get; set; }
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

    [Schema("[dbo].[api_product_edit]")]
    public class Product_Edit_Schema: Header_Schema {
        [InputParameter]
        public int Id { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @ProductCode { get; set; }
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
}