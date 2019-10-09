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
using asset.model.dashboardModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace domain.office._app {
    public interface IGeneric_Container<TEntity> where TEntity : Base_Entity {
        IQueryable<TEntity> GetFindQuery(TEntity model);
        Task<TModel> SingleAsync<TModel>(int id) where TModel : IBase_DashboardModel;
        Task<TEntity> FindSingleAsync(long id, bool force = false);
        Task<List<TEntity>> FindAllAsync(TEntity model, int retrieveLimit = 1000);
        Task<List<TEntity>> GetPagingAsync(TEntity model);
        Task<TEntity> AddAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task<TEntity> RemoveAsync(TEntity model);
    }
    public class Generic_Container<TEntity>: IGeneric_Container<TEntity> where TEntity : Base_Entity {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly SqlDBContext _dbContext;
        public Generic_Container() { }
        public Generic_Container(SqlDBContext dbContext) {
            _dbContext = dbContext;
        }
        public Generic_Container(SqlDBContext dbContext, IMapper mapper) {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #endregion

        public IQueryable<TEntity> GetFindQuery(TEntity model) {
            var query = _dbContext.Set<TEntity>().Select(s => s);
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
        public async Task<TModel> SingleAsync<TModel>(int id) where TModel : IBase_DashboardModel {
            var result = await _dbContext.Set<TEntity>().Where(w => w.Id == id).ProjectTo<TModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return result;
        }
        public async Task<TEntity> FindSingleAsync(long id, bool force = false) {
            var selectedItem = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(s => s.Id == id);
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
        public async Task<List<TEntity>> FindAllAsync(TEntity model, int retrieveLimit) {
            var query = GetFindQuery(model);
            // Pass "zero" for reitrieve all data
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                // Your retrieve limit has been reached
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }
        public async Task<List<TEntity>> GetPagingAsync(TEntity model) {
            var query = GetFindQuery(model);
            model.TotalCount = query.Count();
            query = query.OrderByField(model.OrderBy, model.OrderAscending)
                .Skip(model.Skip).Take(model.Take);
            return await query.ToListAsync();
        }
        public async Task<TEntity> AddAsync(TEntity model) {
            var newItem = await _dbContext.Set<TEntity>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return newItem.Entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity model) {
            await FindSingleAsync(model.Id, true);
            var updatedItem = _dbContext.Set<TEntity>().Update(model);
            await _dbContext.SaveChangesAsync();
            return updatedItem.Entity;
        }
        public async Task<TEntity> RemoveAsync(TEntity model) {
            await FindSingleAsync(model.Id, true);
            model.Status = 10; // 10: Item is removed
            var RemovedItem = _dbContext.Set<TEntity>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return RemovedItem.Entity;
        }
    }
}
