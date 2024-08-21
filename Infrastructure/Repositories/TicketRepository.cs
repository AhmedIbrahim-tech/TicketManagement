using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ITicketRepository : IGenericRepositoryAsync<Ticket>
    {
        Task<IEnumerable<Ticket>> GetPagedTicketsAsync(int pageNumber, int pageSize);
    }

    public class TicketRepository : GenericRepositoryAsync<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetPagedTicketsAsync(int pageNumber, int pageSize)
        {
            var tickets = await _context.Tickets
                .AsNoTracking()
                .OrderBy(t => t.CreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            tickets.ForEach(ticket => ticket.Color = ticket.CalculateTicketColor());

            return tickets;
        }

    }

}
