using asset.utility._app;
using domain.office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.common.office {
    [TestClass]
    public class UserContainer_Test {
        #region ctor
        private readonly IUser_Container _userContainer;
        public UserContainer_Test() {
            _userContainer = ServiceLocator.Current.GetInstance<IUser_Container>();
        }
        #endregion

        [TestMethod, TestCategory("User"), TestCategory("All")]
        public void All() {
            var users = _userContainer.All();
            Assert.IsTrue(users.Any());
        }
    }
}
