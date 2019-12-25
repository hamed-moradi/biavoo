using asset.model.dashboardModels;
using asset.utility._app;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using domain.repository._app;
using domain.repository.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace domain.office._app {
    public interface IPredicateMaker<TEntity> where TEntity : IBase_Entity {
        IQueryable<TEntity> GenerateQuery(Expression<Func<TEntity, bool>> predicate = null, bool pagingSupport = false);
        IQueryable<TModel> GenerateQuery<TModel>(Expression<Func<TEntity, bool>> predicate = null, bool pagingSupport = false) where TModel : Base_DashboardModel;
        IQueryable<TEntity> GenerateQuery(TEntity model, bool pagingSupport = false);
        IQueryable<TModel> GenerateQuery<TModel>(TEntity model, bool pagingSupport = false) where TModel : Base_DashboardModel;
    }
    public class PredicateMaker<TEntity>: IPredicateMaker<TEntity> where TEntity : Base_Entity {
        #region ctor
        private readonly IMapper _mapper;
        private readonly SqlDBContext _dbContext;
        public DbSet<TEntity> Entity { get { return _dbContext.Set<TEntity>(); } }

        public PredicateMaker() {
            _dbContext = ServiceLocator.Current.GetInstance<SqlDBContext>();
            _mapper = ServiceLocator.Current.GetInstance<IMapper>();
        }
        #endregion

        public IQueryable<TEntity> GenerateQuery(Expression<Func<TEntity, bool>> predicate = null, bool pagingSupport = false) {
            var query = Entity.Where(predicate);
            if(pagingSupport) {
                predicate.Body.GetType().GetProperty("TotalCount").SetValue(predicate, query.Count());
                var orderBy = (string)predicate.Body.GetType().GetProperty("OrderBy").GetValue(predicate);
                var orderAsc = (bool)predicate.Body.GetType().GetProperty("Order").GetValue(predicate);
                var skip = (int)predicate.Body.GetType().GetProperty("Skip").GetValue(predicate);
                var take = (int)predicate.Body.GetType().GetProperty("Take").GetValue(predicate);
                query = query.OrderByField(orderBy, orderAsc).Skip(skip).Take(take);
            }
            return query;
        }
        public IQueryable<TModel> GenerateQuery<TModel>(Expression<Func<TEntity, bool>> predicate = null, bool pagingSupport = false)
            where TModel : Base_DashboardModel {
            return GenerateQuery(predicate, pagingSupport).ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }
        public IQueryable<TEntity> GenerateQuery(TEntity model, bool pagingSupport = false) {
            var query = GenerateQuery();
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
            if(pagingSupport) {
                model.TotalCount = query.Count();
                query = query.OrderByField(model.OrderBy, model.OrderAscending)
                    .Skip(model.Skip).Take(model.Take);
            }
            return query;
        }
        public IQueryable<TModel> GenerateQuery<TModel>(TEntity model, bool pagingSupport = false)
            where TModel : Base_DashboardModel {
            return GenerateQuery(model, pagingSupport).ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }
    }
}
