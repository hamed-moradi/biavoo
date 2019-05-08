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
    public class AdminContainer: GenericContainer<Admin>, IAdminContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public AdminContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        #region Private
        private string RandomNumber() {
            var rnd = new Random();
            var number = rnd.Next(1000000, 999999);
            return number.ToString();
        }
        #endregion

        public async Task<Admin> GetById(int id) {
            return await _dbContext.Admins.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Admin>> GetAll(Admin model) {
            var result = await GetPaging(model);
            return result;
        }

        public bool ValidateLastChanged(string lastChanged) {
            return true;
        }

        public async Task<Admin> SignIn(string username, string password) {
            var result = _dbContext.Admins.SingleOrDefaultAsync(admin => admin.Username == username && admin.Password == password);
            return await result;
        }

        public async Task<Admin> GenerateNewPassword(int id) {
            var admin = await GetById(id);
            admin.Password = RandomNumber();
            await _dbContext.SaveChangesAsync();
            return admin;
        }
    }
}
