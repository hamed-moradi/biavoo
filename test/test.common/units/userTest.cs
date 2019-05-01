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

        [TestMethod, TestCategory("User"), TestCategory("SignUp")]
        public async Task SignIn() {
            try {
                var model = new UserSignUpSchema { DeviceId = "", Name = "behzad", Family = "saemi", CellPhone = "911" };
                await _userService.SignUpAsync(model);
                Assert.IsTrue(model.StatusCode > 0);
                Console.WriteLine($"StatusCode: {model.StatusCode}");
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        [TestMethod, TestCategory("User"), TestCategory("SentVerificationCode")]
        public async Task SentVerificationCode() {
            try {
                var model = new UserSendVerificationCodeSchema { Token = "", DeviceId = "", CellPhone = "911" };
                await _userService.SendVerificationCodeAsync(model);
                Assert.IsTrue(model.StatusCode > 0);
                Console.WriteLine($"StatusCode: {model.StatusCode}");
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