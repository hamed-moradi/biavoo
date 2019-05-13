using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using shared.utility;
using shared.utility._app;
using shared.utility.infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class Business_Service: IBusiness_Service {
        #region Constructor
        private readonly IParameterHandler _parameterHandler;
        private readonly IGenericRepository<IBase_Model> _repository;
        private readonly IStoreProcedure<Business_Model, Business_Get_Schema> _get;
        public Business_Service(IParameterHandler parameterHandler,
            IGenericRepository<IBase_Model> repository, 
            IStoreProcedure<Business_Model, Business_Get_Schema> get) {
            _repository = repository;
            _parameterHandler = parameterHandler;
            _get = get;
        }
        #endregion
        public async Task<List<Business_Model>> GetAsync(Business_Get_Schema model) {
            var result = await _get.ExecuteAsync(model);
            return result.ToList();
        }
    }
}
