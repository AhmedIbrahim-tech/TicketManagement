using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository Tickets { get; }
        Task<int> SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
    }
}
