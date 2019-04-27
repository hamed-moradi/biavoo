using domain.application;
using domain.repository.schemas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.utility._app;
using System;
using System.Threading.Tasks;

namespace test.common.units {
    [TestClass]
    public class UserTest {
        #region Constructor
        private readonly IUserService _userService;
        public UserTest() {
            _userService = ServiceLocator.Current.GetInstance<IUserService>();
        }
        #endregion

        [TestMethod, TestCategory("User"), TestCategory("SignIn")]
        public async Task SignIn() {
            try {
                var result = await _userService.SignIn();
                Assert.IsNotNull(result);
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        [TestMethod, TestCategory("User"), TestCategory("GetById")]
        public void GetById() {
            try {
                var result = _userService.Get(1);
                Assert.IsNotNull(result);
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        [TestMethod, TestCategory("User"), TestCategory("SetActivities")]
        public void SetActivities() {
        }
    }
}