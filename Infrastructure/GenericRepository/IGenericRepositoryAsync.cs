using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.GenericRepository;

public interface IGenericRepositoryAsync<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);


    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();

    Task SaveChangesAsync();




}
