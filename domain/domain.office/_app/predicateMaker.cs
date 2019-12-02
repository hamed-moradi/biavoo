using asset.utility._app;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using domain.repository._app;
using domain.repository.entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace domain.office._app {
    public interface IPredicateMaker<TEntity> where TEntity : IBase_Entity {
        IQueryable<TEntity> GenerateQuery(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TModel> GenerateQuery<TModel>(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GenerateQuery(TEntity model, bool pagingSupport = false);
        IQueryable<TModel> GenerateQuery<TModel>(TEntity model, bool pagingSupport = false);
    }
    public class PredicateMaker<TEntity>: IPredicateMaker<TEntity> where TEntity : Base_Entity {
        #region ctor
        private readonly IMapper _mapper;
        private readonly SqlDBContext _dbContext;
        public PredicateMaker(SqlDBContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion
        public IQueryable<TEntity> GenerateQuery(Expression<Func<TEntity, bool>> predicate = null) {
            //return predicate is null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(predicate);
            return _dbContext.Set<TEntity>().Where(predicate);
        }
        public IQueryable<TModel> GenerateQuery<TModel>(Expression<Func<TEntity, bool>> predicate = null) {
            return GenerateQuery(predicate).ProjectTo<TModel>(_mapper.ConfigurationProvider);
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
                query = query.OrderByField(model.OrderBy, model.Order)
                    .Skip(model.Skip).Take(model.Take);
            }
            return query;
        }
        public IQueryable<TModel> GenerateQuery<TModel>(TEntity model, bool pagingSupport = false) {
            return GenerateQuery(model, pagingSupport).ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }
    }
}
