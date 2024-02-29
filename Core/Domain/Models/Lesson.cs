using Domain.Models.Common;

namespace Domain.Models;

public class Lesson : Entity
{
    public string Name { get; set; }
    public byte Credit { get; set; }
    public byte AbsentLimit { get; set; }
    public string ExamId { get; set; }
    public string DepartmentId { get; set; }
    public List<string> TeacherIds { get; set; } = new List<string>();
}