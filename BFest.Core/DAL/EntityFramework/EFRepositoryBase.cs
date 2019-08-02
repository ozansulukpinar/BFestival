using BFest.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Core.DAL.EntityFramework
{
    //Since this class is based from IRepository interface, CRUD operations are implemented.
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        TContext ctx = EFSingletonContext<TContext>.Instance;

        public void Add(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            ctx.SaveChanges();
            //This method saves all changes made in this context to the underlying database.
            //But it only includes add, modify and remove operations.
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return ctx.Set<TEntity>().Where(filter).SingleOrDefault();
            //By this way, lambda expression can be written in Get() method.
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return ctx.Set<TEntity>().ToList();
                //If any filter cannot be chosen, it will get all entities.
            }
            return ctx.Set<TEntity>().Where(filter).ToList();
            //This scenario will be happened when a filter is chosen.
        }

        public void Remove(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges();
            //This method saves all changes made in this context to the underlying database.
            //But it only includes add, modify and remove operations.
        }

        public void Update(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
            //This method saves all changes made in this context to the underlying database.
            //But it only includes add, modify and remove operations.
        }
    }
}
