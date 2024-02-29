using Application.Repositories.IFacultyRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.FacultyRepository
{
    public class ReadFacultyRepository : ReadRepository<Faculty> , IReadFacultyRepository
    {
        public ReadFacultyRepository(AppDbContext context)
            :base(context)
        {
            
        }
    }
}
