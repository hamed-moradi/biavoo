using domain.repository._app;
using domain.repository.entities;
using shared.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared.resource._app;

namespace domain.office._app {
    public interface IGeneric_Container<T> where T : Base_Entity {
        IQueryable<T> GetFindQuery(T model);
        Task<T> FindSingleAsync(long id, bool force = false);
        Task<List<T>> FindAllAsync(T model, int retrieveLimit = 1000);
        Task<List<T>> GetPagingAsync(T model);
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> RemoveAsync(T model);
    }
    public class Generic_Container<T>: IGeneric_Container<T> where T : Base_Entity {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public Generic_Container(SqlDBContext dbContext) {
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
        public async Task<T> FindSingleAsync(long id, bool force = false) {
            var selectedItem = await _dbContext.Set<T>().SingleOrDefaultAsync(s => s.Id == id);
            if(selectedItem == null) {
                if(force) {
                    throw new Exception(InternalMessage.ObjectNotFound, new Exception(GeneralVariables.SystemGeneratedMessage));
                }
                else {
                    return null;
                }
            }
            return selectedItem;
        }
        public async Task<List<T>> FindAllAsync(T model, int retrieveLimit) {
            var query = GetFindQuery(model);
            // Pass "zero" for reitrieve all data
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                // Your retrieve limit has been reached
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }
        public async Task<List<T>> GetPagingAsync(T model) {
            var query = GetFindQuery(model);
            model.TotalCount = query.Count();
            query = query.OrderByField(model.OrderBy, model.OrderAscending)
                .Skip(model.Skip).Take(model.Take);
            return await query.ToListAsync();
        }
        public async Task<T> AddAsync(T model) {
            var newItem = await _dbContext.Set<T>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return newItem.Entity;
        }
        public async Task<T> UpdateAsync(T model) {
            await FindSingleAsync(model.Id, true);
            var updatedItem = _dbContext.Set<T>().Update(model);
            await _dbContext.SaveChangesAsync();
            return updatedItem.Entity;
        }
        public async Task<T> RemoveAsync(T model) {
            await FindSingleAsync(model.Id, true);
            model.Status = 10; // 10: Item is removed
            var RemovedItem = _dbContext.Set<T>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return RemovedItem.Entity;
        }
    }
}
