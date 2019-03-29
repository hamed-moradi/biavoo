using System.Collections.Generic;

namespace domain.repository.entities {
    public partial class DropDownItemModel {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }

    public partial class DropDownItemModel {
        public long RowsCount { get; set; }
    }
}