using domain.entity.collections;
using MongoDB.Driver;
using domain.utility._app;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entity._app {
    public class MongoDBContext {
        #region Constructor
        private static readonly IMongoDatabase mongoDatabase;
        private static readonly object locker = new object();

        static MongoDBContext() {
            lock(locker) {
                if(mongoDatabase == null) {
                    var client = new MongoClient(AppSettings.MongoConnection);
                    var mongodbName = AppSettings.MongoConnection.Split('?')[0].Split('/')[3];
                    mongoDatabase = client.GetDatabase(mongodbName);
                }
            }
        }
        #endregion

        #region Private
        private IMongoCollection<T> Collection<T>() where T : new() {
            return mongoDatabase.GetCollection<T>(typeof(T).Name);
        }
        #endregion

        public IMongoCollection<HttpLog> HttpLogs { get { return Collection<HttpLog>(); } }
    }
}