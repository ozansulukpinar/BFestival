using BFest.DAL.Abstract;
using BFest.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Ninject
{
    public class CustomDALModule : NinjectModule
    {
        //To use dependency injection pattern, Ninject is added from NuGet.
        //Load() method which belongs NinjectModule is overrided and Bind() method which is in this method is used.
        public override void Load()
        {
            Bind<IFestivalDAL>().To<FestivalRepository>();
            Bind<ISeasonDAL>().To<SeasonRepository>();
            Bind<ITicketDAL>().To<TicketRepository>();
            Bind<IUserDAL>().To<UserRepository>();
            Bind<IEvaluationDAL>().To<EvaluationRepository>();
        }
    }
}
