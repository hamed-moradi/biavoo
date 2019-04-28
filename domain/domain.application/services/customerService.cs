using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class CustomerService: ICustomerService {
        #region Constructor
        private readonly IStoreProcedure<CustomerGetByIdModel, GetByIdSchema> _customerGet;
        public CustomerService(IStoreProcedure<CustomerGetByIdModel, GetByIdSchema> customerGet) {
            _customerGet = customerGet;
        }
        #endregion

        public async Task<CustomerGetByIdModel> GetByIdAsync(GetByIdSchema model) {
            return await _customerGet.ExecuteFirstOrDefaultAsync(model);
        }
    }
}
