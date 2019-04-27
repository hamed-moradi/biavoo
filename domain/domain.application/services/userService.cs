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
        private readonly IStoreProcedure<IBaseModel, UserGetByIdSchema> _userGet;
        public UserService(IGenericRepository<IBaseModel> repository,
            IStoreProcedure<IBaseModel, UserGetByIdSchema> userGet) {
            _repository = repository;
            _userGet = userGet;
        }
        #endregion

        public async Task<UserModel> SignIn() {
            return new UserModel { Id = 1 };
        }

        public async Task<UserModel> Get(int id) {
        public async Task<UserModel> Get(GetByIdSchema model) {
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
