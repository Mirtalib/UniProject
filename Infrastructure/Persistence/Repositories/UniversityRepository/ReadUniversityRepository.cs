using Application.Repositories.IUniversityRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.UniversityRepository;

public class ReadUniversityRepository : ReadRepository<University> , IReadUniversityRepository
{
    public ReadUniversityRepository(AppDbContext context)
        : base(context)
    { }
}
