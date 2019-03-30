using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using shared.utility;

namespace domain.repository.models {
    public class CustomerGetByIdModel: IBaseModel {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte? Status { get; set; }
    }
}
