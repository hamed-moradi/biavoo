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
        Task SignInAsync(User_SignIn_Schema model);
        Task<User_Model> SignUpAsync(User_SignUp_Schema model);
        Task SetVerificationCodeAsync(User_SetVerificationCode_Schema model);
        Task VerifyAsync(User_Verify_Schema model);
        Task<User_Model> GetAsync(Void_Schema model);
        Task EnableTwoFactorAuthentication(User_EnableTwoFactorAuthentication_Schema model);
        Task DisableTwoFactorAuthentication(User_DisableTwoFactorAuthentication_Schema model);
        Task UpdateAsync(User_Update_Schema model);
        Task DisableMeAsync(User_DisableMe_Schema model);
    }
    public interface ICustomer_Service {
        Task<User_Model> SignUpAsync(User_SignUp_Schema model);
        Task<Customer_GetById_Model> GetByIdAsync(Void_Schema model);
    }
    public interface ISendMessageQueue_Service {
        Task PutInAsync(SendMessageQueue_PutIn_Schema model);
        Task<List<SendMessageQueue_Model>> GetPagingAsync(SendMessageQueue_GetPaging_Schema model);
    }
    public interface IBusiness_Service {
        Task<List<Business_Model>> GetAsync(Business_Get_Schema model);
    }
}
