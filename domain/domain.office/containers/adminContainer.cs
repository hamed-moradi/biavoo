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
    public class AdminContainer: GenericContainer<Admin>, IAdminContainer {
        #region Constructor
        private readonly MSSqlDBContext _dbContext;
        public AdminContainer(MSSqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public Admin Get(int id) {
            return _dbContext.Admins.SingleOrDefault(sd => sd.Id == id);
        }
    }
}
