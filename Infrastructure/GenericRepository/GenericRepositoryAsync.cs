using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.GenericRepository;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    #region Fields

    protected readonly ApplicationDBContext _context;
    private IDbContextTransaction _transaction;

    #endregion

    #region Constructor (s)
    public GenericRepositoryAsync(ApplicationDBContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods

    #region Methods
    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return _context.Set<T>().AsTracking();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Transaction 
    public IDbContextTransaction BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
        return _transaction;
    }

    public void Commit()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
    }

    public void RollBack()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }
    #endregion

 
    #endregion
}