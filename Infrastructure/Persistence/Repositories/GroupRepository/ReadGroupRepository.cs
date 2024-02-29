using Application.Repositories.IGroupRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.GroupRepository;

public class ReadGroupRepository : ReadRepository<Group> , IReadGroupRepository
{
    public ReadGroupRepository(AppDbContext context)
        : base(context)
    { }
}
