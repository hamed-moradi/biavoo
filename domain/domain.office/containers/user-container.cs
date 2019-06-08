using domain.office._app;
using domain.repository;
using domain.repository._app;
using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.container {
    public class UserContainer: GenericContainer<User_Entity>, IUserContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public UserContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<User_Entity> Get(int id) {
            return await _dbContext.Users.SingleOrDefaultAsync(sd => sd.Id == id);
        }
    }
}
