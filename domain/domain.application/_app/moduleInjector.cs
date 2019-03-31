using domain.application.services;
using domain.repository._app;
using Microsoft.Extensions.DependencyInjection;

namespace domain.application._app {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            //Dapper.EntityFramework.Handlers.Register();
            services.AddSingleton(new ConnectionKeeper());
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton(typeof(IStoreProcedure<,>), typeof(StoreProcedure<,>));
            services.AddTransient<IHttpLogService, HttpLogService>();
            services.AddTransient<IExceptionService, ExceptionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
