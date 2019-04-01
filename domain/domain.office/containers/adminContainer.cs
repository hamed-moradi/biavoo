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
        private readonly SqlDBContext _dbContext;
        public AdminContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public Admin GetById(int id) {
            return _dbContext.Admins.SingleOrDefault(sd => sd.Id == id);
        }

        public List<Admin> GetAll(Admin model) {
            var result = GetPaging(model);
            return result;
        }
    }
}
