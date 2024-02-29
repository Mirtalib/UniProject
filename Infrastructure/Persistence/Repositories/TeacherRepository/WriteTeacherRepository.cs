using Application.Repositories.ITeacherRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.TeacherRepository
{
    public class WriteTeacherRepository : WriteRepository<Teacher> , IWriteTeacherRepository
    {
        public WriteTeacherRepository(AppDbContext context)
            :base(context) 
        {
            
        }
    }
}
