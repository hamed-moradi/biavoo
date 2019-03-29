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
    public class UserContainer: GenericContainer<User>, IUserContainer {
        #region Constructor
        private readonly MSSqlDBContext _dbContext;
        public UserContainer(MSSqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public User Get(int id) {
            return _dbContext.Users.SingleOrDefault(sd => sd.Id == id);
        }
    }
}
