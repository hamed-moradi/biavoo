using domain.utility._app;
using System.Data;
using System.Data.SqlClient;

namespace domain.entity._app {
    public class ConnectionKeeper {
        public static IDbConnection SqlConnection => new SqlConnection(AppSettings.SqlConnection);
    }
}
