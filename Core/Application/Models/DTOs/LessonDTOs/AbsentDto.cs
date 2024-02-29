using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.LessonDTOs
{
    public class AbsentDto
    {
        public byte Absent { get; set; }
        public string LessonId { get; set; }
        public string DepartmentId { get; set; }
    }
}
