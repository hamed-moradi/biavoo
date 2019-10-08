using asset.utility;
using System;
using System.Collections.Generic;

namespace domain.repository.schemas {
    [Schema("[dbo].[api_sendQueue_putIn]")]
    public class SendMessageQueue_PutIn_Schema: Header_Schema {
        [InputParameter]
        public byte TypeId { get; set; }
        [InputParameter]
        public byte CategoryId { get; set; }
        [InputParameter]
        public string CellPhone { get; set; }
        [InputParameter]
        public string Email { get; set; }
        [InputParameter]
        public string Subject { get; set; }
        [InputParameter]
        public string Body { get; set; }
        [InputParameter]
        public string Gateway { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
    [Schema("[dbo].[api_sendQueue_getPaging]")]
    public class SendMessageQueue_GetPaging_Schema: Paging_Schema {
        [InputParameter]
        public byte? @TypeId { get; set; }
        [InputParameter]
        public byte? @CategoryId { get; set; }
        [InputParameter]
        public string @CellPhone { get; set; }
        [InputParameter]
        public string @Email { get; set; }
        [InputParameter]
        public string @Gateway { get; set; }
        [InputParameter]
        public DateTime? @CreatedAt { get; set; }
        [InputParameter]
        public DateTime? @ModifiedAt { get; set; }
        [InputParameter]
        public byte? @Status { get; set; }

        [ReturnParameter]
        public short StatusCode { get; set; }
    }
}