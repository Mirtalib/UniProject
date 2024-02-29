using Application.Repositories.IExamRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.ExamRepository;

public class WriteExamRepository : WriteRepository<Exam> , IWriteExamRepository
{
    public WriteExamRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
