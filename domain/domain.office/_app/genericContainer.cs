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
using System.Linq.Expressions;
using asset.utility._app;

namespace domain.office._app {
    public class Generic_Container<TEntity>: PredicateMaker<TEntity>, IGeneric_Container<TEntity> where TEntity : Base_Entity {
        #region ctor
        private readonly IMapper _mapper;
        private readonly SqlDBContext _dbContext;
        public Generic_Container(SqlDBContext dbContext = null, IMapper mapper = null) : base() {
            _dbContext = dbContext ?? ServiceLocator.Current.GetInstance<SqlDBContext>();
            _mapper = mapper ?? ServiceLocator.Current.GetInstance<IMapper>();
        }
        #endregion

        /// <summary>
        /// Get top 1000 rows by predicate query
        /// </summary>
        /// <param name="predicate">The predicate (bypass by null)</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected entity</returns>
        public List<TEntity> All(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000) {
            var query = GenerateQuery(predicate);
            if(retrieveLimit != 0 && query.Count() > retrieveLimit) {
                // Your retrieve limit has been reached
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return query.ToList();
        }

        /// <summary>
        /// Get asynchrony top 1000 rows by predicate query
        /// </summary>
        /// <param name="predicate">The predicate (bypass by null)</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected entity</returns>
        public async Task<List<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000) {
            var query = GenerateQuery(predicate);
            if(retrieveLimit != 0 && query.Count() > retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get top 1000 rows as TModel by predicate query
        /// </summary>
        /// <param name="predicate">The predicate (bypass by null)</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected model</returns>
        public List<TModel> All<TModel>(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000)
            where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(predicate);
            if(retrieveLimit != 0 && query.Count() > retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return query.ToList();
        }

        /// <summary>
        /// Get asynchrony top 1000 rows as TModel by predicate query
        /// </summary>
        /// <param name="predicate">The predicate (bypass by null)</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected model</returns>
        public async Task<List<TModel>> AllAsync<TModel>(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000)
            where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(predicate);
            if(retrieveLimit != 0 && query.Count() > retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get top 1000 rows by TEntity
        /// </summary>
        /// <param name="entity">The entity (bypass by null)</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected entity</returns>
        public List<TEntity> All(TEntity entity, int retrieveLimit = 1000) {
            var query = GenerateQuery(entity);
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return query.ToList();
        }

        /// <summary>
        /// Get asynchrony top 1000 rows by TEntity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected entity</returns>
        public async Task<List<TEntity>> AllAsync(TEntity entity, int retrieveLimit = 1000) {
            var query = GenerateQuery(entity);
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get top 1000 rows as TModel by TEntity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected model</returns>
        public List<TModel> All<TModel>(TEntity entity, int retrieveLimit = 1000) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(entity);
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return query.ToList();
        }

        /// <summary>
        /// Get asynchrony top 1000 rows as TModel by TEntity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="retrieveLimit">Pass "zero" for reitrieve all data</param>
        /// <returns>A list of selected model</returns>
        public async Task<List<TModel>> AllAsync<TModel>(TEntity entity, int retrieveLimit = 1000) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(entity);
            if(retrieveLimit != 0 && query.Count() >= retrieveLimit) {
                throw new Exception(InternalMessage.RetrieveLimit, new Exception(GeneralVariables.SystemGeneratedMessage));
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get single record by id
        /// </summary>
        /// <param name="id">The record identifier</param>
        /// <param name="force">Throw exception if nothing found</param>
        /// <returns>Selected entity</returns>
        public TEntity Single(long id, bool force = false) {
            var selectedItem = GenerateQuery(s => s.Id == id).SingleOrDefault();
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

        /// <summary>
        /// Get single record by predicate query
        /// </summary>
        /// <param name="id">The record identifier</param>
        /// <param name="force">Throw exception if nothing found</param>
        /// <returns>Selected entity</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate) {
            return GenerateQuery(predicate).SingleOrDefault();
        }

        /// <summary>
        /// Get single record by id
        /// </summary>
        /// <param name="id">The record identifier</param>
        /// <param name="force">Throw exception if nothing found</param>
        /// <returns>Selected model</returns>
        public TModel Single<TModel>(int id, bool force = false) where TModel : Base_DashboardModel {
            var selectedItem = GenerateQuery<TModel>(q => q.Id == id).SingleOrDefault();
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

        /// <summary>
        /// Get single record by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Selected model</returns>
        public TModel Single<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel {
            return GenerateQuery<TModel>(predicate).SingleOrDefault();
        }

        /// <summary>
        /// Get asynchrony single record by id
        /// </summary>
        /// <param name="id">The record identifier</param>
        /// <param name="force">Throw exception if nothing found</param>
        /// <returns>Selected entity</returns>
        public async Task<TEntity> SingleAsync(long id, bool force = false) {
            var selectedItem = await GenerateQuery(q => q.Id == id).SingleOrDefaultAsync();
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

        /// <summary>
        /// Get asynchrony single record by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Selected entity</returns>
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GenerateQuery(predicate).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get asynchrony single record by id
        /// </summary>
        /// <param name="id">The record identifier</param>
        /// <param name="force">Throw exception if nothing found</param>
        /// <returns>Selected model</returns>
        public async Task<TModel> SingleAsync<TModel>(int id, bool force = false) where TModel : Base_DashboardModel {
            var selectedItem = await GenerateQuery<TModel>(q => q.Id == id).SingleOrDefaultAsync();
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

        /// <summary>
        /// Get asynchrony single record by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Selected model</returns>
        public async Task<TModel> SingleAsync<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel {
            return await GenerateQuery<TModel>(predicate).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Get paged result by TEntity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>Paged list of TEntity</returns>
        public List<TEntity> GetPaging(TEntity entity) {
            var query = GenerateQuery(entity, pagingSupport: true);
            return query.ToList();
        }

        /// <summary>
        /// Get paged result by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Paged list of TEntity</returns>
        public List<TEntity> GetPaging(Expression<Func<TEntity, bool>> predicate) {
            var query = GenerateQuery(predicate, pagingSupport: true);
            return query.ToList();
        }

        /// <summary>
        /// Get paged result by TEntity
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>Paged list of TModel</returns>
        public List<TModel> GetPaging<TModel>(TEntity model) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(model, true);
            return query.ToList();
        }

        /// <summary>
        /// Get paged result by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Paged list of TModel</returns>
        public List<TModel> GetPaging<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(predicate, pagingSupport: true);
            return query.ToList();
        }

        /// <summary>
        /// Get paged result asynchrony by TEntity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>Paged list of TEntity</returns>
        public async Task<List<TEntity>> GetPagingAsync(TEntity model) {
            var query = GenerateQuery(model, true);
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get paged result asynchrony by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Paged list of TEntity</returns>
        public async Task<List<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> predicate) {
            var query = GenerateQuery(predicate, pagingSupport: true);
            return await query.ToListAsync();
        }

        /// /// <summary>
        /// Get paged result asynchrony by TEntity
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>Paged list of TModel</returns>
        public async Task<List<TModel>> GetPagingAsync<TModel>(TEntity model) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(model, true);
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get paged result asynchrony by predicate query
        /// </summary>
        /// <param name="predicate">The predicate query</param>
        /// <returns>Paged list of TModel</returns>
        public async Task<List<TModel>> GetPagingAsync<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel {
            var query = GenerateQuery<TModel>(predicate, pagingSupport: true);
            return await query.ToListAsync();
        }


        /// <summary>
        /// Insert new record
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The inserted record</returns>
        public TEntity Add(TEntity entity) {
            var newItem = Entity.Add(entity);
            Save();
            return newItem.Entity;
        }

        /// <summary>
        /// Insert new record asychrony
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The inserted record</returns>
        public async Task<TEntity> AddAsync(TEntity entity) {
            var newItem = await Entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return newItem.Entity;
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The updated record</returns>
        public TEntity Update(TEntity entity) {
            Single(entity.Id, true);
            var updatedItem = Entity.Update(entity);
            Save();
            return updatedItem.Entity;
        }

        /// <summary>
        /// Update record asynchrony
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The updated record</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity) {
            await SingleAsync(entity.Id, true);
            var updatedItem = Entity.Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedItem.Entity;
        }

        public bool Remove(long id) {
            Single(id, true);
            var entity = Single(id, true);
            entity.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(entity);
            Save();
            return modifiedItem.State == EntityState.Modified;
        }

        public bool Remove(TEntity entity) {
            Single(entity.Id, true);
            entity.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(entity);
            Save();
            return modifiedItem.State == EntityState.Modified;
        }

        public bool Remove<TModel>(TModel viewModel) where TModel : Base_DashboardModel {
            var model = Single(viewModel.Id, true);
            model.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(model);
            Save();
            return modifiedItem.State == EntityState.Modified;
        }

        public bool Remove(Expression<Func<TEntity, bool>> predicate) {
            var entities = All(predicate);
            entities.ForEach(e => e.Status = Status.Deleted.ToByte());
            return Save() == 1;
        }

        public async Task<bool> RemoveAsync(long id) {
            Single(id, true);
            var entity = Single(id, true);
            entity.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(entity);
            await SaveAsync();
            return modifiedItem.State == EntityState.Modified;
        }

        public async Task<bool> RemoveAsync(TEntity entity) {
            await SingleAsync(entity.Id, true);
            entity.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(entity);
            await _dbContext.SaveChangesAsync();
            return modifiedItem.State == EntityState.Modified;
        }

        public async Task<bool> RemoveAsync<TModel>(TModel viewModel) where TModel : Base_DashboardModel {
            var model = await SingleAsync(viewModel.Id, true);
            model.Status = Status.Deleted.ToByte();
            var modifiedItem = Entity.Update(model);
            await SaveAsync();
            return modifiedItem.State == EntityState.Modified;
        }

        public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate) {
            var entities = All(predicate);
            entities.ForEach(e => e.Status = Status.Deleted.ToByte());
            return await SaveAsync() == 1;
        }

        public bool Delete(long id) {
            var entity = Single(id, true);
            var result = Entity.Remove(entity);
            Save();
            return result.State == EntityState.Deleted;
        }

        public bool Delete(TEntity entity) {
            var result = Entity.Remove(entity);
            Save();
            return result.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(long id) {
            var entity = Single(id, true);
            var result = Entity.Remove(entity);
            await SaveAsync();
            return result.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(TEntity entity) {
            var result = Entity.Remove(entity);
            await SaveAsync();
            return result.State == EntityState.Deleted;
        }

        public int Save() {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync() {
            return await _dbContext.SaveChangesAsync();
        }
    }
}


