using System.Collections.Generic;

namespace SeliseExamApp.Core.Interfaces
{
    public interface IService<TOne, TTwo> where TOne : class
        where TTwo : class
    {
        TOne Find(int id);
        List<TOne> GetAll();
        void Save(TTwo t);
        void Delete(int id);
    }
}
