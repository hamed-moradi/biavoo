using domain.office._app;
using domain.repository._app;
using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.container {
    public class Product_Container: Generic_Container<Product_Entity>, IProduct_Container {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public Product_Container(SqlDBContext dbContext) : base() {
            _dbContext = dbContext;
        }
        #endregion
        public IDictionary<string,string> MyProperty { get; set; }
        public async Task<Product_Entity> GetByIdAsync(int id) {
            return await _dbContext.Products.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Product_Entity>> GetAllAsync(Product_Entity model) {
            var result = await GetPagingAsync(model);
            return result;
        }
    }
}
