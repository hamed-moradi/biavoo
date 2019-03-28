using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using domain.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class UserService: IUserService {
        #region Constructor
        private readonly IStoreProcedure<UserModel, UserGetSchema> _userGet;
        public UserService(IStoreProcedure<UserModel, UserGetSchema> userGet) {
            _userGet = userGet;
        }
        #endregion

        public async Task<IEnumerable<UserModel>> Get(UserGetSchema model) {
            return await _userGet.ExecuteAsync(model);
        }
    }
}
