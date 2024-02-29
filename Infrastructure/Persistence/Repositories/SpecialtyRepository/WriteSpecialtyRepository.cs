using Application.Repositories.ISpecialtyRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.SpecialtyRepository;

public class WriteSpecialtyRepository : WriteRepository<Specialty> , IWriteSpecialtyRepository
{
    public WriteSpecialtyRepository(AppDbContext context)
        : base(context)
    { }
}
