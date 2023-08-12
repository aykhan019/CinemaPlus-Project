using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class TicketService : IExtendedTicketService
    {
        private readonly ITicketDal _ticketDal;

        public TicketService(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void Add(Ticket entity)
        {
            _ticketDal.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _ticketDal.Delete(entity);
        }

        public List<Ticket> GetAll()
        {
            return _ticketDal.GetList();
        }

        public Ticket GetById(string id)
        {
            return _ticketDal.Get(t => t.Id == id);
        }

        public void Update(Ticket entity)
        {
            _ticketDal.Update(entity);
        }
    }
}
