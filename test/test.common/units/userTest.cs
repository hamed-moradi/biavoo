using domain.application;
using domain.repository.schemas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.utility._app;
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

        [TestMethod, TestCategory("User"), TestCategory("Get")]
        public async Task Get() {
            var model = new GetByIdSchema { Id = 1, EntityName = "[user]" };
            var result = await _userService.Get(model);
            Assert.IsTrue(model.StatusCode == 200, "Worked fine.");
            Assert.IsNotNull(result, "The selected user.");
            Assert.IsNotNull(result.Properties, "User properties");
        }
    }
}