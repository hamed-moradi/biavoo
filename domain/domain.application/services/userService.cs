using Dapper;
using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class UserService: IUserService {
        #region Constructor
        private readonly IGenericRepository<IBaseModel> _repository;
        private readonly IStoreProcedure<UserModel, UserSignUpSchema> _signUp;
        private readonly IStoreProcedure<IBaseModel, UserSendActivationCodeSchema> _sendActivationCode;
        private readonly IStoreProcedure<IBaseModel, UserGetByIdSchema> _get;
        public UserService(IGenericRepository<IBaseModel> repository,
            IStoreProcedure<UserModel, UserSignUpSchema> signUp,
            IStoreProcedure<IBaseModel, UserSendActivationCodeSchema> sendActivationCode,
            IStoreProcedure<IBaseModel, UserGetByIdSchema> get) {
            _repository = repository;
            _signUp = signUp;
            _sendActivationCode = sendActivationCode;
            _get = get;
        }
        #endregion

        public async Task<UserModel> SignUpAsync(UserSignUpSchema model) {
            var result = await _signUp.ExecuteFirstOrDefaultAsync(model);
            return result;
        }

        public async Task SentActivationCodeAsync(UserSendActivationCodeSchema model) {
            await _sendActivationCode.ExecuteReturnLessAsync(model);
        }

        public async Task<UserModel> GetAsync(GetByIdSchema model) {
            //model.EntityName = "[user]";
            var user = new UserModel();
            var parameters = new DynamicParameters();
            parameters.Add("@Token", model.Token, DbType.String, ParameterDirection.Input);
            parameters.Add("@DeviceId", model.DeviceId, DbType.String, ParameterDirection.Input);
            parameters.Add("@Id", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            var result = await _repository.QueryMultipleAsync("dbo.[api_user_getById]", param: parameters, commandType: CommandType.StoredProcedure);
            if(!result.IsConsumed) {
                user = await result.ReadFirstAsync<UserModel>();
            }
            if(!result.IsConsumed) {
                var properties = await result.ReadAsync<UserPropertyModel>();
                if(properties.Any()) {
                    user.Properties = properties.ToList();
                }
            }
            model.StatusCode = parameters.Get<int>("@StatusCode");
            return user;
        }
    }
}