using Application.Repositories.ITeacherRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.TeacherRepository;

public class ReadTeacherRepository : ReadRepository<Teacher> , IReadTeacherRepository
{
    public ReadTeacherRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
