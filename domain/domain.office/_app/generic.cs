using domain.repository._app;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using domain.repository.entities;
using AutoMapper.QueryableExtensions;

namespace domain.office._app {
    public interface IGeneric<M> {
        public E Single<E>(int id) where E : Base_Entity;
    }
    public class Generic<M>: IGeneric<M> {
        #region Constructor
        private readonly SqlDBContext _dbContext;
        public Generic(SqlDBContext dbContext) {
            _dbContext = dbContext;
        }
        #endregion
        public E Single<E>(int id) where E : Base_Entity {
            var result = _dbContext.Set<E>().Where(w => w.Id == id).ProjectTo<E>(null).Single();
            return result;
        }
    }
}
