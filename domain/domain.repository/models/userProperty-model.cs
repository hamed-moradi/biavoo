﻿using asset.utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.repository.models {
    public class UserProperty_Model: IBase_Model {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public byte? PropTypeId { get; set; }
        public string Value { get; set; }
    }
}
