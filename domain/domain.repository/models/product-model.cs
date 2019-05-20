using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Types;
using shared.utility;

namespace domain.repository.models {
    public partial class Product_Model: Paging_Model {
        public int BusinessId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public List<Image_Model> Images { get; set; }
    }
}
