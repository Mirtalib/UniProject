using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.TecherDTOs
{
    public class ViewTeacherProfileDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string DepartmentId { get; set; }
        public List<string> GroupIds { get; set; } = new List<string>();
        public List<string> LessonIds { get; set; } = new List<string>();
    }
}
