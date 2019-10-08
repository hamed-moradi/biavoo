using AutoMapper.QueryableExtensions;
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
    public class Admin_Container: Generic_Container<Admin_Entity>, IAdmin_Container {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public Admin_Container(SqlDBContext dbContext) : base(dbContext) {
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

        public async Task<Admin_Entity> GetByIdAsync(int id) {
            return await _dbContext.Admins.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Admin_Entity>> GetAllAsync(Admin_Entity model) {
            var result = await GetPagingAsync(model);
            return result;
        }

        public bool ValidateLastChangedAsync(string lastChanged) {
            return true;
        }

        public async Task<Admin_Entity> SignInAsync(string username, string password) {
            var result = _dbContext.Admins.SingleOrDefaultAsync(admin => admin.Username == username && admin.Password == password);
            return await result;
        }

        public async Task<Admin_Entity> GenerateNewPasswordAsync(int id) {
            var admin = await GetByIdAsync(id);
            admin.Password = RandomNumber();
            await _dbContext.SaveChangesAsync();
            return admin;
        }
    }
}
