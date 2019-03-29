using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace domain.office._app {
    public static class Extensions {
        public static IMappingExpression<TSource, TDestination> IgnoreAllVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) {
            var desType = typeof(TDestination);
            foreach(var property in desType.GetProperties().Where(p => p.Name.ToLower() != "id" && p.GetGetMethod().IsVirtual)) {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }

        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string sortField, bool ascending) {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            var method = ascending ? "OrderBy" : "OrderByDescending";
            var types = new[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}
