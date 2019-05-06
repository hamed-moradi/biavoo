using Dapper;
using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using shared.utility;
using shared.utility._app;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class UserService: IUser_Service {
        #region Constructor
        private readonly IGenericRepository<IBase_Model> _repository;
        private readonly IStoreProcedure<User_Model, User_SignUp_Schema> _signUp;
        private readonly IStoreProcedure<IBase_Model, User_SendVerificationCode_Schema> _sendVerificationCode;
        private readonly IStoreProcedure<IBase_Model, User_EnableTwoFactorAuthentication_Schema> _enableTwoFactorAuthentication;
        private readonly IStoreProcedure<IBase_Model, User_DisableTwoFactorAuthentication_Schema> _disableTwoFactorAuthentication;
        public UserService(IGenericRepository<IBase_Model> repository,
            IStoreProcedure<User_Model, User_SignUp_Schema> signUp,
            IStoreProcedure<IBase_Model, User_SendVerificationCode_Schema> sendVerificationCode,
            IStoreProcedure<IBase_Model, User_EnableTwoFactorAuthentication_Schema> enableTwoFactorAuthentication,
            IStoreProcedure<IBase_Model, User_DisableTwoFactorAuthentication_Schema> disableTwoFactorAuthentication) {
            _repository = repository;
            _signUp = signUp;
            _sendVerificationCode = sendVerificationCode;
            _enableTwoFactorAuthentication = enableTwoFactorAuthentication;
            _disableTwoFactorAuthentication = disableTwoFactorAuthentication;
        }
        #endregion

        public async Task SignUpAsync(User_SignUp_Schema model) {
            await _signUp.ExecuteReturnLessAsync(model);
        }

        public async Task SendVerificationCodeAsync(User_SendVerificationCode_Schema model) {
            await _sendVerificationCode.ExecuteReturnLessAsync(model);
        }

        public async Task<User_Model> GetAsync(GetById_Schema model) {
            //model.EntityName = "[user]";
            var user = new User_Model();
            var parameters = new DynamicParameters();
            parameters.Add("@Token", model.Token, DbType.String, ParameterDirection.Input);
            parameters.Add("@DeviceId", model.DeviceId, DbType.String, ParameterDirection.Input);
            parameters.Add("@Id", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@StatusCode", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);
            var result = await _repository.QueryMultipleAsync("dbo.[api_user_getById]", param: parameters, commandType: CommandType.StoredProcedure);
            if(!result.IsConsumed) {
                user = await result.ReadFirstAsync<User_Model>();
            }
            if(!result.IsConsumed) {
                var properties = await result.ReadAsync<UserProperty_Model>();
                if(properties.Any()) {
                    user.Properties = properties.ToList();
                }
            }
            model.StatusCode = parameters.Get<short>("@StatusCode");
            return user;
        }
        public async Task EnableTwoFactorAuthentication(User_EnableTwoFactorAuthentication_Schema model) {
            await _enableTwoFactorAuthentication.ExecuteReturnLessAsync(model);
        }
        public async Task DisableTwoFactorAuthentication(User_DisableTwoFactorAuthentication_Schema model) {
            await _disableTwoFactorAuthentication.ExecuteReturnLessAsync(model);
        }
    }
}