using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office._app {
    public partial class SqlDBContext: DbContext {
        public virtual DbSet<Admin_Entity> Admins { get; set; }
    }
}