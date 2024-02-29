using Domain.Models.Common;

namespace Domain.Models;

public class Department : Entity
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public string UniversityId { get; set; }
    public List<string> TeacherIds { get; set; } = new List<string>();
    public List<string> LessonIds { get; set; } = new List<string>();
}