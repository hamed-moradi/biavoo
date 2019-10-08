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
    public class ModuleReference_Container: Generic_Container<ModuleReference_Entity>, IModuleReference_Container {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public ModuleReference_Container(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<ModuleReference_Entity> GetByIdAsync(int id) {
            return await _dbContext.ModuleReferences.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<ModuleReference_Entity>> GetAllAsync(ModuleReference_Entity model) {
            var result = GetPagingAsync(model);
            return await result;
        }

        public async Task<List<ModuleReference_Entity>> GetByAdminIdAsync(int adminId) {
            return await (from module in _dbContext.ModuleReferences
                          join permission in _dbContext.Role2Modules on module.Id equals permission.ModuleId
                          join role in _dbContext.Roles on permission.RoleId equals role.Id
                          join admin in _dbContext.Admins on role.Id equals admin.RoleId
                          where admin.Id == adminId
                          select module).ToListAsync();
        }
    }
}
