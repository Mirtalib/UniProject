using Application.Repositories.ISpecialtyRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.SpecialtyRepository;

public class ReadSpecialtyRepository : ReadRepository<Specialty> , IReadSpecialtyRepository
{
    public ReadSpecialtyRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
