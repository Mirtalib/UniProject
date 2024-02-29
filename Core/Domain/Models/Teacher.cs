using Domain.Models.Common;

namespace Domain.Models;

public class Teacher : User
{
    public string DepartmentId { get; set; }
    public List<string> GroupIds { get; set; } = new List<string>();
    public List<string> LessonIds { get; set; } = new List<string>();

}