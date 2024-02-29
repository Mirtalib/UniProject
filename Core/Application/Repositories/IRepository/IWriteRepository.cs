using Domain.Models.Common;

namespace Application.Repositories.IRepository;

public interface IWriteRepository<T> where T : Entity
{
    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    bool Update(T entity);
    bool Remove(T entity);

    Task<int> SaveChangesAsync();
}
