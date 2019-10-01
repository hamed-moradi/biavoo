using shared.utility._app;
using System.Data;
using Microsoft.Data.SqlClient;

namespace domain.repository._app {
    public class ConnectionKeeper {
        public static IDbConnection SqlConnection => new SqlConnection(AppSettings.SqlConnection);
    }
}
