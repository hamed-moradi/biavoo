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
        private readonly IStoreProcedure<CustomerGetByIdModel, CustomerGetByIdSchema> _customerGet;
        public CustomerService(IStoreProcedure<CustomerGetByIdModel, CustomerGetByIdSchema> customerGet) {
            _customerGet = customerGet;
        }
        #endregion

        public async Task<CustomerGetByIdModel> GetById(CustomerGetByIdSchema model) {
            return await _customerGet.ExecuteFirstOrDefaultAsync(model);
        }
    }
}
