using BFest.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Core.DAL
{
    public interface IRepository<TEntity>
         where TEntity : BaseEntity
    {
        //CRUD that are consist of Create, Read, Update and Delete operations are defined in this base.
        //If this interface will be implemented by a class, it should be in Entity type.
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
