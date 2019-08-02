using BFest.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Model
{
    //The access modifier of this class should be public.
    //Since it should be accessible for all other layers except Core one.
    public class Evaluation:BaseEntity
    {
        //All properties that an evaluation can have are identified.
        public string Comment { get; set; }
        public DateTime Date { get; set; }


        //This points to primary key in related tables.
        public int FestivalID { get; set; }
        public int UserID { get; set; }

        //Navigation property of Evaluation
        //It provides a way to navigate an association between two entity types.
        public virtual Festival Festival { get; set; }
        public virtual User User { get; set; }
    }
}
