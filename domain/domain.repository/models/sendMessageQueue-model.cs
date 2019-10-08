using asset.utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.repository.models {
    public class SendMessageQueue_Model: IBase_Model {
        public byte TypeId { get; set; }
        public byte CategoryId { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
