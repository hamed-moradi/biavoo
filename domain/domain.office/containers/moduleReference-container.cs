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
    public class ModuleReferenceContainer: GenericContainer<ModuleReference>, IModuleReferenceContainer {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public ModuleReferenceContainer(SqlDBContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<ModuleReference> GetById(int id) {
            return await _dbContext.ModuleReferences.SingleOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<List<ModuleReference>> GetAll(ModuleReference model) {
            var result = GetPaging(model);
            return await result;
        }

        public async Task<List<ModuleReference>> GetByAdminId(int adminId) {
            return await (from module in _dbContext.ModuleReferences
                          join permission in _dbContext.Role2Modules on module.Id equals permission.ModuleId
                          join role in _dbContext.Roles on permission.RoleId equals role.Id
                          join admin in _dbContext.Admins on role.Id equals admin.RoleId
                          where admin.Id == adminId
                          select module).ToListAsync();
        }
    }
}
