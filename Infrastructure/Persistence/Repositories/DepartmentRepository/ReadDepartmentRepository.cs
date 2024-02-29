using Application.Repositories.IDepartmentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.DepartmentRepository;

public class ReadDepartmentRepository : ReadRepository<Department> ,IReadDepartmentRepository
{
    public ReadDepartmentRepository(AppDbContext context)
        : base(context)
    {}
}
