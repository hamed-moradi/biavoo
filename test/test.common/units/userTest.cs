using domain.application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared.utility._app;

namespace test.common.units {
    [TestClass]
    public class UserTest {
        #region Constructor
        private readonly IUserService _userService;
        public UserTest() {
            _userService = ServiceLocator.Current.GetInstance<IUserService>();
        }
        #endregion
        [TestMethod]
        [TestCategory("User")]
        [TestCategory("SetActivities")]
        public void SetActivities() {
        }
    }
}