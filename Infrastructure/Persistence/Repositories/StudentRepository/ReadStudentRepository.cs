using Application.Repositories.IStudentRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.StudentRepository;

public class ReadStudentRepository : ReadRepository<Student> , IReadStudentRepository
{
    public ReadStudentRepository(AppDbContext context)
        : base(context)
    {
        
    }
}
