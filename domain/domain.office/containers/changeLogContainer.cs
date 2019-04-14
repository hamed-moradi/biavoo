using domain.office._app;
using domain.repository;
using domain.repository._app;
using domain.repository.entities;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.container {
    public class ChangeLogContainer: GenericContainer<ChangeLog>, IChangeLogContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public ChangeLogContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public List<ChangeLog> GetAll(ChangeLog model) {
            var result = GetPaging(model);
            return result;
        }
    }
}
