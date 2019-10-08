using asset.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_image_get]")]
    public class Image_Get_Schema: IBase_Schema {
        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}