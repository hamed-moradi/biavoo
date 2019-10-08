using asset.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {

    [Schema("[dbo].[api_comment_getPaging]")]
    public class Comment_GetPaging_Schema: Paging_Schema {
        [InputParameter]
        public int @EntityId { get; set; }
        [InputParameter]
        public string @Entity { get; set; }
        [InputParameter]
        public string @Keyword { get; set; }

        [ReturnParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[api_comment_new]")]
    public class Comment_New_Schema: Header_Schema {
        [InputParameter]
        public int? @ParentId { get; set; }
        [InputParameter]
        public int @EntityId { get; set; }
        [InputParameter]
        public string @Entity { get; set; }
        [InputParameter]
        public string @Body { get; set; }

        [ReturnParameter]
        public short @StatusCode { get; set; }
    }

    [Schema("[dbo].[api_comment_edit]")]
    public class Comment_Edit_Schema: Header_Schema {
        [InputParameter]
        public int @Id { get; set; }
        [InputParameter]
        public string @Body { get; set; }

        [ReturnParameter]
        public short @StatusCode { get; set; }
    }
}