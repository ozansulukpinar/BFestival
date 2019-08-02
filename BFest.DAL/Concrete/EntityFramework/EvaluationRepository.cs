using BFest.Core.DAL.EntityFramework;
using BFest.DAL.Abstract;
using BFest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.DAL.Concrete.EntityFramework
{
   public class EvaluationRepository:EFRepositoryBase<Evaluation, BFestDbContext>,IEvaluationDAL
    {
    }
}
