using domain.repository.collections;
using domain.repository.models;
using domain.repository.schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.application {
    public interface IException_Service {
        Task InsertAsync(Exception model, string url, string ip);
    }
    public interface IHttpLog_Service {
        Task<int> InsertAsync(HttpLog model, int timeoutMS = 256);
    }
    public interface IUser_Service {
        Task SignUpAsync(User_SignUp_Schema model);
        Task SetVerificationCodeAsync(User_SetVerificationCode_Schema model);
        Task VerifyAsync(User_Verify_Schema model);
        Task<User_Model> GetAsync(GetById_Schema model);
        Task EnableTwoFactorAuthentication(User_EnableTwoFactorAuthentication_Schema model);
        Task DisableTwoFactorAuthentication(User_DisableTwoFactorAuthentication_Schema model);
    }
    public interface ICustomer_Service {
        Task<Customer_GetById_Model> GetByIdAsync(GetById_Schema model);
    }
    public interface ISendMessageQueue_Service {

    }
}
