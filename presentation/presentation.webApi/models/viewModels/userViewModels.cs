using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.viewModels {
    public class User_ViewModel: IBaseViewModel {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public List<UserProperty_ViewModel> Properties { get; set; }
    }
}
