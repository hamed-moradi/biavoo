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
    public class ProductContainer: GenericContainer<Product>, IProductContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public ProductContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<Product> GetById(int id) {
            return await _dbContext.Products.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Product>> GetAll(Product model) {
            var result = await GetPaging(model);
            return result;
        }

        public bool ValidateLastChanged(string lastChanged) {
            return true;
        }
    }
}
