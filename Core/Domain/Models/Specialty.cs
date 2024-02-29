using Domain.Models.Common;

namespace Domain.Models;

public class Specialty : Entity
{
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public string FacultyId { get; set; } 
    public List<string> GroupIds { get; set; } = new List<string>();
}
