using BFest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.DAL.Concrete.EntityFramework
{
    class Strategy : DropCreateDatabaseIfModelChanges<BFestDbContext>
    {
        protected override void Seed(BFestDbContext context)
        {
            var seasons = new List<Season>
            {
                new Season { SeasonName = "İlkbahar" },
                new Season { SeasonName = "Jazz" },
                new Season { SeasonName = "Metal" },
                new Season { SeasonName = "Alternative" }
            };

            var festivals = new List<Festival>
            {
                new Festival {Name = "İlkbahar Fest" },
                new Festival {Name = "İlkbahar Fest2" },
                new Festival {Name = "İlkbahar Fest3" },
                new Festival {Name = "Yaz Fest" },
                new Festival {Name = "Yaz Fest2" },
                new Festival {Name = "Sonbahar Fest" },
                new Festival {Name = "Sonbahar Fest2" },
                new Festival {Name = "Kış Fest" },
                new Festival {Name = "Kış Fest2" }
            };

            var users = new List<User>
            {
                new User {Name = "Ahmet", Email = "aa@a.a", Password = "123", Phone = "5552552211", Surname = "Musa", TCNo= "11122211122"},
                new User {Name = "Mustafa", Email = "bb@b.b", Password = "123", Phone = "5552552211", Surname = "Musa", TCNo= "11122211333"},
                new User {Name = "Ali", Email = "cc@c.c", Password = "123", Phone = "5552552211", Surname = "Musa", TCNo= "11652231122"},
                new User {Name = "Murat", Email = "dd@d.d", Password = "123", Phone = "5552552211", Surname = "Musa", TCNo= "65666211122"},
            };

            //var tickets = new List<Ticket>
            //{
            //new Ticket { UserID = 1, FestivalID = 1, Price = 8.99M },
            //new Ticket { UserID = 2, FestivalID = 4, Price = 8.99M },
            //new Ticket { UserID = 3, FestivalID = 2, Price = 8.99M },
            //new Ticket { UserID = 2, FestivalID = 6, Price = 8.99M },
            //new Ticket { UserID = 2, FestivalID = 2, Price = 8.99M },
            //new Ticket { UserID = 3, FestivalID = 2, Price = 8.99M },
            // };

            context.Seasons.AddRange(seasons);
            context.Festivals.AddRange(festivals);
            context.Users.AddRange(users);
           // context.Tickets.AddRange(tickets);
            context.SaveChanges();
            //This method saves all changes made in this context to the underlying database.
        }
    }
}
