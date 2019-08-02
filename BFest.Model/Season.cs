using BFest.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Model
{
    //The access modifier of this class should be public.
    //Since it should be accessible for all other layers except Core one.
    public class Season : BaseEntity
    {
        //Property that a season can have is identified.
        public string SeasonName { get; set; }

        //Navigation property of Season
        //It provides a way to navigate an association between two entity types.
        public virtual List<Festival> Festivals { get; set; }

    }
}
