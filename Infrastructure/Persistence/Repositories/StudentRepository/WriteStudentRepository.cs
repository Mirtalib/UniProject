using Application.Repositories.IStudentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.StudentRepository;

public class WriteStudentRepository : WriteRepository<Student> , IWriteStudentRepository
{
    public WriteStudentRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
