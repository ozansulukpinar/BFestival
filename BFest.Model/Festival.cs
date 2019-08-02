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
    public class Festival : BaseEntity
    {
        //All properties that a festival can have are identified.
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int AgeLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //This points to primary key in related tables.
        public int SeasonID { get; set; }

        //Navigation properties of Festival
        //These provide a way to navigate an association between two entity types.
        public virtual List<Ticket> Tickets { get; set; }
        public virtual Season Season { get; set; }
        public virtual List<Evaluation> Evaluations { get; set; }
    }
}
