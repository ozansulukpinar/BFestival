using BFest.BLL.Abstract;
using BFest.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFest.Model;
using BFest.DAL.Concrete.EntityFramework;

namespace BFest.BLL.Concrete
{
    public class FestivalService : IFestivalService
    {
        IFestivalDAL _festivalDAL;
       

        public FestivalService(IFestivalDAL festivalDAL)
        {
            _festivalDAL = festivalDAL;
            
        }


        //It deletes selected festival.
        public void Delete(Festival entity)
        {
            _festivalDAL.Remove(entity);
        }

        //It deletes a festival according to ID.
        public void DeleteByID(int entityID)
        {
            Festival festival = _festivalDAL.Get(z => z.ID == entityID);
            _festivalDAL.Remove(festival);
        }

        //It brings selected festival.
        public Festival Get(int entityID)
        {
            return _festivalDAL.Get(z => z.ID == entityID);
        }

        //It brings all past and future festivals.
        public ICollection<Festival> GetAll()
        {
            return _festivalDAL.GetAll();
        }

       //It brings all future festivals.
        public List<Festival> GetAllFutureFestivals()
        {
            return _festivalDAL.GetAll().Where(z => z.StartDate > DateTime.Now).ToList();
        }

       //It brings all past festivals.
        public List<Festival> GetAllPastFestivals()
        {
            return _festivalDAL.GetAll().Where(z => z.StartDate < DateTime.Now).ToList();
        }

        //It brings all past and future festivals according to SeasonID.
        public List<Festival> GetFestivalsBySeasonID(int seasonID)
        {
            return _festivalDAL.GetAll().Where(z => z.SeasonID == seasonID).ToList();
        }

        //It brings all future festivals according to SeasonID.
        public List<Festival> GetFutureFestivalsBySeasonID(int seasonID)
        {
            return _festivalDAL.GetAll().Where(z => z.SeasonID == seasonID && z.StartDate > DateTime.Now).ToList();
        }
        //It brings all past festivals according to SeasonID.
        public List<Festival> GetPastFestivalsBySeasonID(int seasonID)
        {
            return _festivalDAL.GetAll().Where(z => z.SeasonID == seasonID && z.StartDate < DateTime.Now).ToList();
        }

        //It adds new festival.
        public void Insert(Festival entity)
        {
            _festivalDAL.Add(entity);
        }
        
        //It updates selected festival.
        public void Update(Festival entity)
        {
            _festivalDAL.Update(entity);
        }                   

    }
}
