using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : Entity, new()
    {
        ICollection<T> Get();
        ICollection<T> GetByCondition(Expression<Func<T, bool>> condition);
        T Get(int id);
        T Insert(T t);
        T Update(T t);
        void Delete(T t);
    }
}
