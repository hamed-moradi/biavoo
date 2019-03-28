using domain.repository._app;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test.common._app {
    [TestClass]
    public class Startup {
        [AssemblyInitialize]
        public static void Init(TestContext testContext) {
            var services = new ServiceCollection();
            services.AddSingleton(new MongoDBContext());
            domain.utility._app.ModuleInjector.Init(services);
            domain.application._app.ModuleInjector.Init(services);
            services.AddSingleton(new domain.utility._app.ServiceLocator(services));
        }
    }

    [TestClass]
    public class Cleanup {
        [AssemblyCleanup]
        public static void Init() {
        }
    }
}