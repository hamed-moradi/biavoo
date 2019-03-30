using domain.application._app;
using domain.repository.models;
using domain.repository.schemas;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.application.services {
    public class UserService: IUserService {
        #region Constructor
        private readonly IStoreProcedure<UserGetByIdModel, UserGetByIdSchema> _userGet;
        public UserService(IStoreProcedure<UserGetByIdModel, UserGetByIdSchema> userGet) {
            _userGet = userGet;
        }
        #endregion

        public async Task<UserGetByIdModel> Get(int id) {
            return await _userGet.ExecuteFirstOrDefaultAsync("");
        }
    }
}
