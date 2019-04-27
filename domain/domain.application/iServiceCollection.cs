using domain.repository.collections;
using domain.repository.models;
using domain.repository.schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.application {
    public interface IExceptionService {
        Task InsertAsync(Exception model, string url, string ip);
    }
    public interface IHttpLogService {
        Task<int> InsertAsync(HttpLog model, int timeoutMS = 256);
    }
    public interface IUserService {
        Task<UserModel> SignIn();
        Task<UserModel> Get(int id);
        Task<UserModel> Get(GetByIdSchema model);
    }
    public interface ICustomerService {
        Task<CustomerGetByIdModel> GetById(CustomerGetByIdSchema model);
    }
}
