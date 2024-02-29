using Domain.Models.Common;

namespace Domain.Models;

public class University : Entity
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public List<string> FacultyIds { get; set; } = new List<string>();
    public List<string> DepartmentIds { get; set; } = new List<string>();
}