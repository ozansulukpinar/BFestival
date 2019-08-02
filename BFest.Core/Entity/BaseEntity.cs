using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Core.Entity
{
    public abstract class BaseEntity
    {
        //This serves as the primary unique identifier for each entity instance.
        public int ID { get; set; }
    }
}
