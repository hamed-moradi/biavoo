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
    public class BusinessContainer: GenericContainer<Business>, IBusinessContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public BusinessContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<Business> GetById(int id) {
            return await _dbContext.Businesses.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Business>> GetAll(Business model) {
            var result = await GetPaging(model);
            return result;
        }

        public bool ValidateLastChanged(string lastChanged) {
            return true;
        }
    }
}
