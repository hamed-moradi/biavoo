using shared.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_user_getById]")]
    public class UserGetByIdSchema: IBaseSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public int @Id { get; set; }

        [HelperParameter]
        public int StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_getPaging]")]
    public class UserGetPagingSchema: PagingSchema {
        [InputParameter]
        public string @Token { get; set; }
        [InputParameter]
        public string @DeviceId { get; set; }
        [InputParameter]
        public string @Title { get; set; }
        [InputParameter]
        public DateTime? @FromDate { get; set; }
        [InputParameter]
        public DateTime? @ToDate { get; set; }

        [HelperParameter]
        public int @StatusCode { get; set; }
    }
}