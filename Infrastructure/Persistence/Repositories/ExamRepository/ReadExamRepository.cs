using Application.Repositories.IExamRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ExamRepository
{
    public class ReadExamRepository : ReadRepository<Exam> , IReadExamRepository
    {
        public ReadExamRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
