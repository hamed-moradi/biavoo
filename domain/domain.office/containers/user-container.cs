using domain.office._app;
using domain.repository;
using domain.repository._app;
using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using asset.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.container {
    public class User_Container: Generic_Container<User_Entity>, IUser_Container {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public User_Container(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        //public async Task<User_Entity> GetByIdAsync(int id) {
        //    return await _dbContext.Users.SingleOrDefaultAsync(sd => sd.Id == id);
        //}
    }
}
