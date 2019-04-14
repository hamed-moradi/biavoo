using domain.office._app;
using domain.repository.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.office {
    public interface IChangeLogContainer: IGenericContainer<ChangeLog> {
        List<ChangeLog> GetAll(ChangeLog model);
    }
    public interface IAdminContainer: IGenericContainer<Admin> {
        Task<Admin> GetById(int id);
        Task<List<Admin>> GetAll(Admin model);
        Task<Admin> SignIn(string username, string password);
        Task<Admin> GenerateNewPassword(int id);
    }
    public interface IModuleReferenceContainer: IGenericContainer<ModuleReference> {
        ModuleReference GetById(int id);
        List<ModuleReference> GetAll(ModuleReference model);
    }
    public interface IUserContainer: IGenericContainer<User> {
        User Get(int id);
    }
}
