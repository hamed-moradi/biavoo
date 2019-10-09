using System;
using System.Collections.Generic;
using System.Text;

namespace asset.model.dashboardModels {
    public class Category_DashboardModel: IBase_DashboardModel {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }
}
