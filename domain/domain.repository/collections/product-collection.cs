using MongoDB.Bson;
using asset.utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace domain.repository.collections {
    public class Product: IBase_Collection {
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public string Properties { get; set; }
    }
}