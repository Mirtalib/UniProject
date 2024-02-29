using Application.Repositories.IRepository;
using Domain.Models;

namespace Application.Repositories.ILessonRepository;

public interface IWriteLessonRepository : IWriteRepository<Lesson>
{
}
