using domain.office._app;
using domain.repository.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.office {
    public interface IChangeLog_Container: IGeneric_Container<ChangeLog_Entity> {
        Task<List<ChangeLog_Entity>> GetAllAsync(ChangeLog_Entity model);
    }
    public interface IAdmin_Container: IGeneric_Container<Admin_Entity> {
        Task<Admin_Entity> GetByIdAsync(int id);
        Task<List<Admin_Entity>> GetAllAsync(Admin_Entity model);
        bool ValidateLastChangedAsync(string lastChanged);
        Task<Admin_Entity> SignInAsync(string username, string password);
        Task<Admin_Entity> GenerateNewPasswordAsync(int id);
    }
    public interface IModuleReference_Container: IGeneric_Container<ModuleReference_Entity> {
        Task<ModuleReference_Entity> GetByIdAsync(int id);
        Task<List<ModuleReference_Entity>> GetAllAsync(ModuleReference_Entity model);
        Task<List<ModuleReference_Entity>> GetByAdminIdAsync(int adminId);
    }
    public interface IUser_Container: IGeneric_Container<User_Entity> {
        //Task<User_Entity> GetByIdAsync(int id);
    }
    public interface IProduct_Container: IGeneric_Container<Product_Entity> { }
    public interface IBusiness_Container: IGeneric_Container<Business_Entity> {
        Task<Business_Entity> GetByIdAsync(int id);
        Task<List<Business_Entity>> GetAllAsync(Business_Entity model);
    }
    public interface ICategory_Container: IGeneric_Container<Category_Entity> { }
}
