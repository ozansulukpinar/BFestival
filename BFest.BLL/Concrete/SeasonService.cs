
using BFest.BLL.Abstract;
using BFest.DAL.Abstract;
using BFest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Concrete
{
    public class SeasonService : ISeasonService
    {
        ISeasonDAL _seasonDAL;

        public SeasonService(ISeasonDAL seasonDAL)
        {
            _seasonDAL = seasonDAL;
        }

        //It deletes selected season.
        public void Delete(Season entity)
        {
            _seasonDAL.Remove(entity);
        }

        //It deletes a season according to ID.
        public void DeleteByID(int entityID)
        {
            Season season = _seasonDAL.Get(z => z.ID == entityID);
            _seasonDAL.Remove(season);

        }

        //It brings selected season.
        public Season Get(int entityID)
        {
            return _seasonDAL.Get(z => z.ID == entityID);
        }

        //It brings all seasons.
        public ICollection<Season> GetAll()
        {
            return _seasonDAL.GetAll();
        }

        //It adds new season.
        public void Insert(Season entity)
        {
            _seasonDAL.Add(entity);
        }

        //It updates selected season.
        public void Update(Season entity)
        {
            _seasonDAL.Update(entity);
        }
    }
}
