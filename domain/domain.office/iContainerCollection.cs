using domain.office._app;
using domain.repository.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.office {
    public interface IChangeLogContainer: IGenericContainer<ChangeLog> {
        Task<List<ChangeLog>> GetAll(ChangeLog model);
    }
    public interface IAdminContainer: IGenericContainer<Admin> {
        Task<Admin> GetById(int id);
        Task<List<Admin>> GetAll(Admin model);
        bool ValidateLastChanged(string lastChanged);
        Task<Admin> SignIn(string username, string password);
        Task<Admin> GenerateNewPassword(int id);
    }
    public interface IModuleReferenceContainer: IGenericContainer<ModuleReference> {
        Task<ModuleReference> GetById(int id);
        Task<List<ModuleReference>> GetAll(ModuleReference model);
        Task<List<ModuleReference>> GetByAdminId(int adminId);
    }
    public interface IUserContainer: IGenericContainer<User> {
        Task<User> Get(int id);
    }
}
