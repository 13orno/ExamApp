using System;
using System.Linq;
using System.Linq.Expressions;

namespace SeliseExamApp.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(long id);
        void InsertOrUpdate(T t);
        void Delete(long id);
        void Save();
    }
}
