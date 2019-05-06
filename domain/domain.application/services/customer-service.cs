using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class CustomerService: ICustomer_Service {
        #region Constructor
        private readonly IStoreProcedure<Customer_GetById_Model, GetById_Schema> _customerGet;
        public CustomerService(IStoreProcedure<Customer_GetById_Model, GetById_Schema> customerGet) {
            _customerGet = customerGet;
        }
        #endregion

        public async Task<Customer_GetById_Model> GetByIdAsync(GetById_Schema model) {
            return await _customerGet.ExecuteFirstOrDefaultAsync(model);
        }
    }
}
