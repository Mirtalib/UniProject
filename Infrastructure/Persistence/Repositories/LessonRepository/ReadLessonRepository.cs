using Application.Repositories.ILessonRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.LessonRepository
{
    public class ReadLessonRepository : ReadRepository<Lesson> , IReadLessonRepository
    {
        public ReadLessonRepository(AppDbContext context)
            :base(context)
        {
            
        }
    }
}
