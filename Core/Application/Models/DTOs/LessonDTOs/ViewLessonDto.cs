using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.LessonDTOs
{
    public class ViewLessonDto
    {
        public string Name { get; set; }
        public byte Credit { get; set; }
        public byte AbsentLimit { get; set; }
        public string ExamId { get; set; }
        public string DepartmentId { get; set; }
    }
}