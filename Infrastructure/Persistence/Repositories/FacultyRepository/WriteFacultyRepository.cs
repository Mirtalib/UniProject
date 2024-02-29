using Application.Repositories.IFacultyRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.FacultyRepository;

public class WriteFacultyRepository : WriteRepository<Faculty> , IWriteFacultyRepository
{
    public WriteFacultyRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
