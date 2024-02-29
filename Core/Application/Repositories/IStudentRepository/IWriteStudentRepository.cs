using Application.Repositories.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.IStudentRepository
{
    public interface IWriteStudentRepository : IWriteRepository<Student>
    {
    }
}
