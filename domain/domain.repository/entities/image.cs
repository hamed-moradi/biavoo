using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using domain.repository.entities;

namespace domain.repository.models {
    [Table("dbo.[image]")]
    public class Image: BaseEntity {
        public int? Id { get; set; }
        public int? EntityId { get; set; }
        public int? TypeId { get; set; }
        public string Entity { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
