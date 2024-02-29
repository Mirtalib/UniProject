using Application.Repositories.IGroupRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.GroupRepository;

public class WriteGroupRepository: WriteRepository<Group> , IWriteGroupRepository
{
    public WriteGroupRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
