using domain.utility;
using domain.utility._app;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.repository.schemas {
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

        [OutputParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[api_user_get]")]
    public class UserGetSchema: IBaseSchema {
        [InputParameter]
        public string @PersonelIds { get; set; }
        [InputParameter]
        public string @EventTypeIds { get; set; }
        [InputParameter]
        public string @ActivityPDate { get; set; }
        [InputParameter]
        public DateTime? @StopTime { get; set; }
        [InputParameter]
        public DateTime? @FromTime { get; set; }
        [InputParameter]
        public DateTime? @ToTime { get; set; }
        [InputParameter]
        public int? @MaxAccurancy { get; set; }

        [OutputParameter]
        public short @StatusCode { get; set; }
    }
}