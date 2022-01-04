using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    /*Esta clase extiende de la interfaz IReposiotyBase
     la cual es la que define los metodos que son aplicables
    en mas de una Entidad
      */
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private Context _Context;

        public RepositoryBase(Context context)
        {
            _Context = context;
        }

        public IQueryable<T> FindAll()
        {
            return _Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FinByCondition(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _Context.Set<T>().Add(entity);
        }
        
        public void Update(T entity)
        {
            _Context.Set<T>().Update(entity);

        }

        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public void SaveAsync()
        {
            _Context.SaveChanges();
        }
    }
}
