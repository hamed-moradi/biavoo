using System.Data;
using System.Data.SqlClient;

namespace domain.office._app {
    public class ConnectionKeeper {
        public static IDbConnection SqlConnection => new SqlConnection(AppSettings.ConnectionString);
    }
}
