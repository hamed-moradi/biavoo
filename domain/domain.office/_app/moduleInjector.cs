using domain.office.container;
using domain.repository._app;
using Microsoft.Extensions.DependencyInjection;

namespace domain.office._app {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            services.AddSingleton(new MSSqlDBContext());
            services.AddSingleton(typeof(IGenericContainer<>), typeof(GenericContainer<>));
            services.AddTransient<IAdminContainer, AdminContainer>();
        }
    }
}
