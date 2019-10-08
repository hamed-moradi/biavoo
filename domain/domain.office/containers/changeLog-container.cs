using domain.office._app;
using domain.repository;
using domain.repository._app;
using domain.repository.entities;
using asset.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.container {
    public class ChangeLog_Container: Generic_Container<ChangeLog_Entity>, IChangeLog_Container {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public ChangeLog_Container(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<List<ChangeLog_Entity>> GetAllAsync(ChangeLog_Entity model) {
            var result = GetPagingAsync(model);
            return await result;
        }
    }
}
