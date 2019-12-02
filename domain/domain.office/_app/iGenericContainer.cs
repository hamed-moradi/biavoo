using asset.model.dashboardModels;
using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace domain.office._app {
    public interface IGeneric_Container<TEntity>: IPredicateMaker<TEntity> where TEntity : Base_Entity {

        List<TEntity> All(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000);
        List<TModel> All<TModel>(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000) where TModel : Base_DashboardModel;
        List<TEntity> All(TEntity model, int retrieveLimit = 1000);
        List<TModel> All<TModel>(TEntity model, int retrieveLimit = 1000) where TModel : Base_DashboardModel;

        Task<List<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000);
        Task<List<TModel>> AllAsync<TModel>(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000) where TModel : Base_DashboardModel;
        Task<List<TEntity>> AllAsync(TEntity model, int retrieveLimit = 1000);
        Task<List<TModel>> AllAsync<TModel>(TEntity model, int retrieveLimit = 1000) where TModel : Base_DashboardModel;

        TEntity Single(long id, bool force = false);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleAsync(long id, bool force = false);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        TModel Single<TModel>(int id, bool force = false) where TModel : Base_DashboardModel;
        Task<TModel> SingleAsync<TModel>(int id, bool force = false) where TModel : Base_DashboardModel;
        Task<List<TEntity>> GetPagingAsync(TEntity model);
        Task<List<TModel>> GetPagingAsync<TModel>(TEntity model) where TModel : Base_DashboardModel;
        Task<TEntity> AddAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task<EntityState> RemoveAsync(TEntity model);
        Task<EntityState> RemoveAsync<TModel>(TModel viewModel) where TModel : Base_DashboardModel;
        int Save();
        Task<int> SaveAsync();
    }
}
