﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.repository.entities {

    [Table("dbo.[appSetting]")]
    public partial class AppSetting_Entity: Base_Entity {
        [Key]
        public new int? Id { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int? Priority { get; set; }
    }
    public partial class AppSetting_Entity {
    }

}
