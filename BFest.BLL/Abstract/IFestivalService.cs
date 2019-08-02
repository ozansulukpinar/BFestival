using BFest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Abstract
{
    public interface IFestivalService : IBaseService<Festival>
    {
        List<Festival> GetFestivalsBySeasonID(int seasonID);
        List<Festival> GetAllFutureFestivals();
        List<Festival> GetAllPastFestivals();
        List<Festival> GetFutureFestivalsBySeasonID(int seasonID);
        List<Festival> GetPastFestivalsBySeasonID(int seasonID);
        
    }
}
