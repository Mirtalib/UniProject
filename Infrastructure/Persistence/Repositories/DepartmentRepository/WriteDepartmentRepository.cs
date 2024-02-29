using Application.Repositories.IDepartmentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.DepartmentRepository;

public class WriteDepartmentRepository : WriteRepository<Department> , IWriteDepartmentRepository
{
    public WriteDepartmentRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
