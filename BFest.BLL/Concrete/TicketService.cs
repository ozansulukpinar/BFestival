
using BFest.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFest.Model;
using BFest.BLL.Abstract;

namespace BFest.BLL.Concrete
{
    public class TicketService : ITicketService
    {
        ITicketDAL _ticketDAL;
        public TicketService(ITicketDAL ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }

        //It deletes selected ticket.
        public void Delete(Ticket entity)
        {
            _ticketDAL.Remove(entity);
        }

        //It deletes a ticket according to ID.
        public void DeleteByID(int entityID)
        {
            Ticket ticket = _ticketDAL.Get(z => z.ID == entityID);
            _ticketDAL.Remove(ticket);
        }

        //It brings selected ticket.
        public Ticket Get(int entityID)
        {
            return _ticketDAL.Get(z => z.ID == entityID);
        }

        //It brings all tickets.
        public ICollection<Ticket> GetAll()
        {
            return _ticketDAL.GetAll();
        }

        //It adds new ticket.
        public void Insert(Ticket entity)
        {
            _ticketDAL.Add(entity);
        }

        //It updates selected ticket.
        public void Update(Ticket entity)
        {
            _ticketDAL.Update(entity);
        }
    }
}
