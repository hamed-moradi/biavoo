using shared.utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.repository.models {
    public class UserModel: IBaseModel {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<UserPropertyModel> Properties { get; set; }
    }
}
