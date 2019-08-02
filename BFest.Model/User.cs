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
    public class User : BaseEntity
    {
        //All properties that an user can have are identified.
        public string TCNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Authority { get; set; }

        //Navigation property of User
        //It provides a way to navigate an association between two entity types.
        public virtual List<Ticket> Ticket { get; set; }
        public virtual List<Evaluation> Evaluation { get; set; }

    }
}
