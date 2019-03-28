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
    public interface IUserService {
        Task<IEnumerable<UserModel>> Get(UserGetSchema model);
    }
    public interface IHttpLogService {
        Task<int> InsertAsync(HttpLog model, int timeoutMS = 256);
    }
}
