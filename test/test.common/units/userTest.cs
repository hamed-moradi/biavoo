using domain.application;
using domain.repository.schemas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.utility._app;
using System;
using System.Linq;
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
                var result = await _userService.SignInAsync();
                Assert.IsNotNull(result);
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        [TestMethod, TestCategory("User"), TestCategory("GetById")]
        public async Task GetById() {
            try {
                var model = new GetByIdSchema { Id = 1, EntityName = "[user]" };
                var result = await _userService.GetAsync(model);
                Assert.IsTrue(model.StatusCode > 0);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Properties.Any());
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