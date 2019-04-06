using domain.repository._app;
using domain.repository.entities;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.office._app {
    public interface IGenericContainer<T> where T : BaseEntity {
        IQueryable<T> GetFindQuery(T model);
        List<T> Find(T model, int retrieveLimit = 1000);
        List<T> GetPaging(T model);
    }
    public class GenericContainer<T>: IGenericContainer<T> where T : BaseEntity {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public GenericContainer(SqlDBContext dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public IQueryable<T> GetFindQuery(T model) {
            var query = _dbContext.Set<T>().Select(s => s);
            var properties = model.GetType().GetProperties().Where(item 
                => !Attribute.IsDefined(item, typeof(NotMappedAttribute))
                && !Attribute.IsDefined(item, typeof(ForeignKeyAttribute)));
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
        public List<T> GetPaging(T model) {
            var query = GetFindQuery(model);
            model.RowsCount = query.Count();
            query = query.Skip(model.Skip).Take(model.Take);
            return query.ToList();
        }
    }
}
