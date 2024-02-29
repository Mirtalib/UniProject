using Application.Repositories.ILessonRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.LessonRepository;

public class WriteLessonRepository : WriteRepository<Lesson> , IWriteLessonRepository
{
    public WriteLessonRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
