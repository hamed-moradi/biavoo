using domain.office.container;
using domain.repository._app;
using Microsoft.Extensions.DependencyInjection;
using asset.utility._app;
using Microsoft.EntityFrameworkCore;

namespace domain.office._app {
    public class ModuleInjector {
        public static void Init(IServiceCollection services) {
            services.AddDbContextPool<SqlDBContext>(options => options.UseSqlServer(AppSettings.SqlConnection), poolSize: 64);
            services.AddSingleton(typeof(IGeneric_Container<>), typeof(Generic_Container<>));
            services.AddTransient<IAdmin_Container, Admin_Container>();
            services.AddTransient<IUser_Container, User_Container>();
        }
    }
}
