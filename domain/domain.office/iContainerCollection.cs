using domain.office._app;
using domain.repository.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.office {
    public interface IChangeLogContainer: IGenericContainer<ChangeLog_Entity> {
        Task<List<ChangeLog_Entity>> GetAll(ChangeLog_Entity model);
    }
    public interface IAdminContainer: IGenericContainer<Admin_Entity> {
        Task<Admin_Entity> GetById(int id);
        Task<List<Admin_Entity>> GetAll(Admin_Entity model);
        bool ValidateLastChanged(string lastChanged);
        Task<Admin_Entity> SignIn(string username, string password);
        Task<Admin_Entity> GenerateNewPassword(int id);
    }
    public interface IModuleReferenceContainer: IGenericContainer<ModuleReference> {
        Task<ModuleReference> GetById(int id);
        Task<List<ModuleReference>> GetAll(ModuleReference model);
        Task<List<ModuleReference>> GetByAdminId(int adminId);
    }
    public interface IUserContainer: IGenericContainer<User> {
        Task<User> Get(int id);
    }
    public interface IProductContainer: IGenericContainer<Product> { }
    public interface IBusinessContainer: IGenericContainer<Business_Entity> { }
}
