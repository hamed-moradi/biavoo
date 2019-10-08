using domain.repository._app;
using domain.repository.entities;
using asset.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using asset.resource._app;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using asset.model.dashboardModels;

namespace domain.office._app {
    public interface IGeneric_Container<Entity> where Entity : Base_Entity {
        IQueryable<Entity> GetFindQuery(Entity model);
        Task<Model> SingleAsync<Model>(int id) where Model : IBase_DashboardModel;
        Task<Entity> FindSingleAsync(long id, bool force = false);
        Task<List<Entity>> FindAllAsync(Entity model, int retrieveLimit = 1000);
        Task<List<Entity>> GetPagingAsync(Entity model);
        Task<Entity> AddAsync(Entity model);
        Task<Entity> UpdateAsync(Entity model);
        Task<Entity> RemoveAsync(Entity model);
    }
    public class Generic_Container<Entity>: IGeneric_Container<Entity> where Entity : Base_Entity {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public Generic_Container(SqlDBContext dbContext) {
            _dbContext = dbContext;
        }
        #endregion

        public IQueryable<Entity> GetFindQuery(Entity model) {
            var query = _dbContext.Set<Entity>().Select(s => s);
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
        public async Task<Model> SingleAsync<Model>(int id) where Model : IBase_DashboardModel {
            var result = await _dbContext.Set<Entity>().Where(w => w.Id == id).ProjectTo<Model>(null).SingleOrDefaultAsync();
            return result;
        }
        public async Task<Entity> FindSingleAsync(long id, bool force = false) {
            var selectedItem = await _dbContext.Set<Entity>().SingleOrDefaultAsync(s => s.Id == id);
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
        public async Task<List<Entity>> FindAllAsync(Entity model, int retrieveLimit) {
            var query = GetFindQuery(model);
            // Pass "zero" for reitrieve all data
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                // Your retrieve limit has been reached
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }
        public async Task<List<Entity>> GetPagingAsync(Entity model) {
            var query = GetFindQuery(model);
            model.TotalCount = query.Count();
            query = query.OrderByField(model.OrderBy, model.OrderAscending)
                .Skip(model.Skip).Take(model.Take);
            return await query.ToListAsync();
        }
        public async Task<Entity> AddAsync(Entity model) {
            var newItem = await _dbContext.Set<Entity>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return newItem.Entity;
        }
        public async Task<Entity> UpdateAsync(Entity model) {
            await FindSingleAsync(model.Id, true);
            var updatedItem = _dbContext.Set<Entity>().Update(model);
            await _dbContext.SaveChangesAsync();
            return updatedItem.Entity;
        }
        public async Task<Entity> RemoveAsync(Entity model) {
            await FindSingleAsync(model.Id, true);
            model.Status = 10; // 10: Item is removed
            var RemovedItem = _dbContext.Set<Entity>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return RemovedItem.Entity;
        }
    }
}
