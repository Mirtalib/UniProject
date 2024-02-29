using Application.Repositories.IRepository;
using Domain.Models;

namespace Application.Repositories.ITeacherRepository;

public interface IWriteTeacherRepository : IWriteRepository<Teacher>
{
}
