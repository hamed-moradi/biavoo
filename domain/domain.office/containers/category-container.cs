
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
using AutoMapper;

namespace domain.office.container {
    public class Category_Container: Generic_Container<Category_Entity>, ICategory_Container {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly SqlDBContext _dbContext;
        public Category_Container(SqlDBContext dbContext, IMapper mapper) : base() {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #endregion

        public async Task<Category_Entity> GetByIdAsync(int id) {
            return await _dbContext.Categories.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<Category_Entity>> GetAllAsync(Category_Entity model) {
            var result = await GetPagingAsync(model);
            return result;
        }
    }
}
