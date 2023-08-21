using Cinema.Business.Abstraction.Extensions;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Models;

namespace Cinema.Business.Concrete
{
    public class TicketService : IExtendedTicketService
    {
        private readonly ITicketDal _ticketDal;

        public TicketService(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public async Task AddAsync(Ticket entity)
        {
            await _ticketDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Ticket entity)
        {
            await _ticketDal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _ticketDal.GetListAsync();
        }

        public async Task<Ticket> GetByIdAsync(string id)
        {
            return await _ticketDal.GetAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Ticket entity)
        {
            await _ticketDal.UpdateAsync(entity);
        }
    }
}
