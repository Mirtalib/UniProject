using Application.Repositories.IRepository;
using Domain.Models;

namespace Application.Repositories.IExamRepository;

public interface IWriteExamRepository : IWriteRepository<Exam>
{
}
