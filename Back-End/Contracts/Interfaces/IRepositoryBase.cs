using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts.Interfaces
{
    /*Esta Interfaz define los metodos genericos que son aplicables
     * para cualquier entidad */
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FinByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveAsync();


    }
}
