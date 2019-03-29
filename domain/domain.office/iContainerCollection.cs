using domain.office._app;
using domain.repository.entities;
using System;

namespace domain.office {
    public interface IAdminContainer: IGenericContainer<Admin> {
        Admin Get(int id);
    }
    public interface IUserContainer: IGenericContainer<User> {
        User Get(int id);
    }
}
