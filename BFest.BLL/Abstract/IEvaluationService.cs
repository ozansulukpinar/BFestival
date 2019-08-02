﻿using BFest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Abstract
{
  public  interface IEvaluationService: IBaseService<Evaluation>
    {
        List<Evaluation> GetAllEvaluationsByFestivalID(int festivalID);
    }
}
