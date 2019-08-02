using BFest.Core;
using BFest.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Abstract
{
    public interface IBaseService<T>
         where T : BaseEntity
    {
        void Insert(T entity);
        void Delete(T entity);
        void DeleteByID(int entityID);
        void Update(T entity);
        T Get(int entityID);
        ICollection<T> GetAll();
        //CRUD that are consist of Create, Read, Update and Delete operations are defined in this base.
    }
}
