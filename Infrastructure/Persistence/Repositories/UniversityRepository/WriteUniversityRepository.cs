using Application.Repositories.IUniversityRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.UniversityRepository;

public class WriteUniversityRepository : WriteRepository<University> , IWriteUniversityRepository
{
    public WriteUniversityRepository(AppDbContext context)
        : base(context)
    { }
}
