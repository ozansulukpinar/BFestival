using BFest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.DAL.Concrete.EntityFramework
{
    public class BFestDbContext : DbContext
    {
        //SQL Server authentication is used to connect to the SQL Server database.
        public BFestDbContext() : base("Server=.;Database=BFest;UID=sa;PWD=123;")
        {
          //  Database.SetInitializer<BFestDbContext>(new Strategy());
        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));
            //Type of properties whose type is datetime should be changed because SQL does not support this type.
            //If a changing in model will be happened, this can be possible by overriding OnModelCreating() method.         
        }

    }
}
