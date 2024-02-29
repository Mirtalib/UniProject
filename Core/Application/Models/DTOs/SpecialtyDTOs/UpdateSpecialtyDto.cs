using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.SpecialtyDTOs
{
    public class UpdateSpecialtyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FacultyId { get; set; }
    }
}
