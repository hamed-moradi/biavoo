using domain.office._app;
using domain.repository.entities;
using System;
using System.Collections.Generic;

namespace domain.office {
    public interface IAdminContainer: IGenericContainer<Admin> {
        Admin GetById(int id);
        List<Admin> GetAll(Admin model);
    }
    public interface IUserContainer: IGenericContainer<User> {
        User Get(int id);
    }
}
