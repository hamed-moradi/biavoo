using domain.office._app;
using domain.office.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.office.containers {
    public class ConfigurationContainer {
        #region ctor
        private readonly MyDbContext _myDbContext;
        public ConfigurationContainer() {
            //_myDbContext = new MyDbContext();
        }
        #endregion

        public Configuration Get() {
            var result = _myDbContext.Configurations.Find();
            return result;
        }
    }
}
