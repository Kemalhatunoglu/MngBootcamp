using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.GenericRepository.EntityFramework
{
    internal class EfGenericRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : Entity, new()
        where TContext : DbContext, new()
    {
        public ICollection<TEntity> Get()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(condition).ToList();
            }
        }

        public TEntity Insert(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return t;
            }
        }

        public TEntity Update(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return t;
            }
        }

        public void Delete(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
