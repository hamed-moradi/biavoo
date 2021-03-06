﻿using System;
using System.Collections.Generic;
using System.Text;
using asset.utility;

namespace domain.repository.models {
    public class Customer_Model: IBase_Model {
        public string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }
    public class Customer_GetById_Model: IBase_Model {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }
}
