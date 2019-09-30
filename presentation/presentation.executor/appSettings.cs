using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serilog;

namespace presentation.executor {
    public static class AppSettings {
        #region ctor
        private static readonly IConfiguration _configuration;
        static AppSettings() {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        }
        #endregion

        public static string Url { get { return _configuration["client:url"]; } }
        public static string Uri { get { return _configuration["client:uri"]; } }
        public static string SystemToken => _configuration["client:cystemToken"];
        public static string SystemDeviceId => _configuration["client:cystemDeviceId"];

        public static string TypeId { get { return _configuration["request:typeId"]; } }
        public static string CategoryId => _configuration["request:categoryId"];
        public static string CellPhone => _configuration["request:cellPhone"];
        public static string EMail => _configuration["request:eMail"];
        public static string Gateway => _configuration["request:gateway"];
        public static string OrderBy => _configuration["request:orderby"];
        public static string Order => _configuration["request:order"];
        public static string PageSize => _configuration["request:pageSize"];
    }
}
