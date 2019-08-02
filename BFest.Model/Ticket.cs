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
    public class Ticket : BaseEntity
    {
        //These point to primary key in related tables.
        public int FestivalID { get; set; }
        public int UserID { get; set; }

        //Navigation properties of Ticket
        //These provide a way to navigate an association between two entity types.
        public virtual User User { get; set; }
        public virtual Festival Festival { get; set; }
    }
}
