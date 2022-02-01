using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : Entity
    {
        //Linq,Predicate,Expression,Func,Delegate
        //Bu reponun Async olmayan versiyonu yazılacak Ödevleri genel alanda paylaşılacak
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                   int index = 0,
                                   int size = 10,
                                   bool enableTracing = true,
                                   CancellationToken cancellationToken = default);
        IQueryable<TEntity> Query();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
