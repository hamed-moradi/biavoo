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
        List<TEntity> All(TEntity entity, int retrieveLimit = 1000);
        List<TModel> All<TModel>(TEntity entity, int retrieveLimit = 1000) where TModel : Base_DashboardModel;

        Task<List<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000);
        Task<List<TModel>> AllAsync<TModel>(Expression<Func<TEntity, bool>> predicate = null, int retrieveLimit = 1000) where TModel : Base_DashboardModel;
        Task<List<TEntity>> AllAsync(TEntity entity, int retrieveLimit = 1000);
        Task<List<TModel>> AllAsync<TModel>(TEntity entity, int retrieveLimit = 1000) where TModel : Base_DashboardModel;

        TEntity Single(long id, bool force = false);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TModel Single<TModel>(int id, bool force = false) where TModel : Base_DashboardModel;
        TModel Single<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel;

        Task<TEntity> SingleAsync(long id, bool force = false);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TModel> SingleAsync<TModel>(int id, bool force = false) where TModel : Base_DashboardModel;
        Task<TModel> SingleAsync<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel;

        List<TEntity> GetPaging(TEntity entity);
        List<TEntity> GetPaging(Expression<Func<TEntity, bool>> predicate);
        List<TModel> GetPaging<TModel>(TEntity entity) where TModel : Base_DashboardModel;
        List<TModel> GetPaging<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel;

        Task<List<TEntity>> GetPagingAsync(TEntity entity);
        Task<List<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TModel>> GetPagingAsync<TModel>(TEntity entity) where TModel : Base_DashboardModel;
        Task<List<TModel>> GetPagingAsync<TModel>(Expression<Func<TEntity, bool>> predicate) where TModel : Base_DashboardModel;

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        bool Remove(long id);
        bool Remove(TEntity entity);
        bool Remove<TModel>(TModel viewModel) where TModel : Base_DashboardModel;
        bool Remove(Expression<Func<TEntity, bool>> predicate);

        Task<bool> RemoveAsync(long id);
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> RemoveAsync<TModel>(TModel viewModel) where TModel : Base_DashboardModel;
        Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> predicate);

        bool Delete(long id);
        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteAsync(TEntity entity);

        int Save();
        Task<int> SaveAsync();
    }
}
