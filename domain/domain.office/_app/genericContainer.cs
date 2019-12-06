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
        public Generic_Container(SqlDBContext dbContext = null, IMapper mapper = null) : base(dbContext, mapper) {
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

        public TEntity Add(TEntity model) {
            var newItem = _dbContext.Set<TEntity>().Add(model);
            Save();
            return newItem.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity model) {
            var newItem = await _dbContext.Set<TEntity>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return newItem.Entity;
        }

        public TEntity Update(TEntity model) {
            Single(model.Id, true);
            var updatedItem = _dbContext.Set<TEntity>().Update(model);
            Save();
            return updatedItem.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity model) {
            await SingleAsync(model.Id, true);
            var updatedItem = _dbContext.Set<TEntity>().Update(model);
            await _dbContext.SaveChangesAsync();
            return updatedItem.Entity;
        }

        public EntityState Remove(TEntity model) {
            Single(model.Id, true);
            model.Status = Status.Deleted.ToByte();
            var RemovedItem = _dbContext.Set<TEntity>().Remove(model);
            Save();
            return RemovedItem.State;
        }

        public EntityState Remove<TModel>(TModel viewModel) where TModel : Base_DashboardModel {
            var model = Single(viewModel.Id, true);
            model.Status = Status.Deleted.ToByte();
            var removedItem = _dbContext.Set<TEntity>().Remove(model);
            Save();
            return removedItem.State;
        }

        public async Task<EntityState> RemoveAsync(TEntity model) {
            await SingleAsync(model.Id, true);
            model.Status = Status.Deleted.ToByte();
            var RemovedItem = _dbContext.Set<TEntity>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return RemovedItem.State;
        }

        public async Task<EntityState> RemoveAsync<TModel>(TModel viewModel) where TModel : Base_DashboardModel {
            var model = await SingleAsync(viewModel.Id, true);
            model.Status = Status.Deleted.ToByte();
            var removedItem = _dbContext.Set<TEntity>().Remove(model);
            await _dbContext.SaveChangesAsync();
            return removedItem.State;
        }

        public int Save() {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveAsync() {
            return await _dbContext.SaveChangesAsync();
        }
    }
}


