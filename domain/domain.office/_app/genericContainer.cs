using domain.repository._app;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace domain.office._app {
    public interface IGenericContainer<T> where T : class {
        IQueryable<T> GetFindQuery(T model);
        List<T> Find(T model, int retrieveLimit = 1000);
        List<T> GetPaging(IQueryable<T> query, out long totalCount, int skip = 0, int take = 10);
    }
    public class GenericContainer<T>: IGenericContainer<T> where T : class {
        #region Constructor
        private readonly Type _type;
        private readonly MSSqlDBContext _dbContext;
        public GenericContainer(MSSqlDBContext dbContext) {
            _type = typeof(T);
            _dbContext = dbContext;
        }
        #endregion
        public IQueryable<T> GetFindQuery(T model) {
            var query = _dbContext.Set<T>().Select(s => s);
            var properties = model.GetType().GetProperties();
            foreach(var prp in properties) {
                var key = prp.Name;
                var value = prp.GetValue(model, null);
                if(value != null) {
                    query = query.Where(w => w.GetType().GetProperty(key).GetValue(model) == value);
                }
            }
            return query;
        }
        public List<T> Find(T model, int retrieveLimit) {
            var query = GetFindQuery(model);
            // Pass "zero" for reitrieve all data
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                // Your retrieve limit has been reached
                throw new Exception(GeneralMessage.retrieveLimit, new Exception(GeneralVariables.systemGeneratedMessage));
            }
            return query.ToList();
        }
        public List<T> GetPaging(IQueryable<T> query, out long totalCount, int skip, int take) {
            totalCount = query.Count();
            query = query.Skip(skip).Take(take);
            return query.ToList();
        }
    }
}
