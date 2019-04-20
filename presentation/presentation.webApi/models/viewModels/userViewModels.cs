using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presentation.webApi.models.viewModels {
    public class UserGetViewModel: IBaseViewModel {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Fullname { get; set; }
        public string Avatar { get; set; }
        public List<UserPropertyViewModel> Properties { get; set; }
    }
}
