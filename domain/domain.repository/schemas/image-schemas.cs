using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_image_get]")]
    public class Image_Get_Schema: IBase_Schema {
        [InputParameter]
        public int @BusinessId { get; set; }
        [InputParameter]
        public int @CategoryId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @ThumbImage { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }

    [Schema("[dbo].[api_image_getPaging]")]
    public class Image_GetPaging_Schema: Paging_Schema {
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

    [Schema("[dbo].[api_image_new]")]
    public class Image_New_Schema: Header_Schema {
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @IageCode { get; set; }
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

    [Schema("[dbo].[api_image_edit]")]
    public class Image_Edit_Schema: Header_Schema {
        [InputParameter]
        public int Id { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public string @Description { get; set; }
        [InputParameter]
        public string @Address { get; set; }
        [InputParameter]
        public string @IageCode { get; set; }
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