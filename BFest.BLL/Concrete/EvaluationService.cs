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
    public class EvaluationService:IEvaluationService
    {
        IEvaluationDAL _evaluationDAL;

        public EvaluationService(IEvaluationDAL evaluationDAL)
        {
            _evaluationDAL = evaluationDAL;
        }

        //It deletes selected evaluation.
        public void Delete(Evaluation entity)
        {
            _evaluationDAL.Remove(entity);
        }

        //It deletes an evaluation according to ID.
        public void DeleteByID(int entityID)
        {
            Evaluation evaluation = _evaluationDAL.Get(z => z.ID == entityID);
            _evaluationDAL.Remove(evaluation);
        }

        //It brings selected evaluation.
        public Evaluation Get(int entityID)
        {
            return _evaluationDAL.Get(z => z.ID == entityID);
        }

        //It brings all evaluations.
        public ICollection<Evaluation> GetAll()
        {
            return _evaluationDAL.GetAll();
        }

        //It brings all evaluations according to ID.
        public List<Evaluation> GetAllEvaluationsByFestivalID(int festivalID)
        {
            return _evaluationDAL.GetAll().Where(x => x.FestivalID == festivalID).ToList();
        }

        //It adds new evaluation.
        public void Insert(Evaluation entity)
        {
            _evaluationDAL.Add(entity);
        }

        //It updates selected evaluation.
        public void Update(Evaluation entity)
        {
            _evaluationDAL.Update(entity);
        }
    }
}
