using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared.model.viewModels {
    public class Customer_GetById_ViewModel: IBaseViewModel {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Avatar { get; set; }
    }
}
