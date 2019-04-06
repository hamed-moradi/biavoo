using domain.office._app;
using domain.repository;
using domain.repository._app;
using domain.repository.entities;
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

        public ModuleReference GetById(int id) {
            return _dbContext.ModuleReferences.SingleOrDefault(sd => sd.Id == id);
        }

        public List<ModuleReference> GetAll(ModuleReference model) {
            var result = GetPaging(model);
            return result;
        }
    }
}
