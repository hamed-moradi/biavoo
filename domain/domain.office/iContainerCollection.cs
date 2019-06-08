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
    public interface IModuleReferenceContainer: IGenericContainer<ModuleReference_Entity> {
        Task<ModuleReference_Entity> GetById(int id);
        Task<List<ModuleReference_Entity>> GetAll(ModuleReference_Entity model);
        Task<List<ModuleReference_Entity>> GetByAdminId(int adminId);
    }
    public interface IUserContainer: IGenericContainer<User_Entity> {
        Task<User_Entity> Get(int id);
    }
    public interface IProductContainer: IGenericContainer<Product_Entity> { }
    public interface IBusinessContainer: IGenericContainer<Business_Entity> { }
}
