using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using shared.utility;
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
        private readonly IStoreProcedure<Business_Model, Business_GetByLocation_Schema> _get;
        private readonly IStoreProcedure<Business_Model, Business_GetPaging_Schema> _getPaging;
        private readonly IStoreProcedure<Business_Model, Business_New_Schema> _new;
        private readonly IStoreProcedure<Business_Model, Business_Edit_Schema> _edit;
        public Business_Service(
            IParameterHandler parameterHandler,
            IGenericRepository<IBase_Model> repository, 
            IStoreProcedure<Business_Model, Business_GetByLocation_Schema> get,
            IStoreProcedure<Business_Model, Business_GetPaging_Schema> getPaging,
            IStoreProcedure<Business_Model, Business_New_Schema> @new,
            IStoreProcedure<Business_Model, Business_Edit_Schema> edit) {
            _repository = repository;
            _parameterHandler = parameterHandler;
            _get = get;
            _getPaging = getPaging;
            _new = @new;
            _edit = edit;
        }
        #endregion
        public async Task<List<Business_Model>> GetByLocationAsync(Business_GetByLocation_Schema model) {
            var result = await _get.ExecuteAsync(model);
            return result.ToList();
        }
        public async Task<List<Business_Model>> GetPagingAsync(Business_GetPaging_Schema model) {
            var result = await _getPaging.ExecuteAsync(model);
            model.TotalCount = result.Any() ? result.Single().TotalCount : 0;
            return result.ToList();
        }
        public async Task<Business_Model> NewAsync(Business_New_Schema model) {
            var result = await _new.ExecuteFirstOrDefaultAsync(model);
            return result;
        }

        public async Task<Business_Model> EditAsync(Business_Edit_Schema model) {
            var result = await _edit.ExecuteFirstOrDefaultAsync(model);
            return result;
        }
    }
}
