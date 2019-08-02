using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.Core.DAL.EntityFramework
{
    public class EFSingletonContext<TContext>
       where TContext : DbContext, new()
    {
        //By using encapsulation, one of the SOLID principles, only one instance can be taken. So that singleton pattern was applied.
        private static TContext _context;

        public static TContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }
        }
    }
}
