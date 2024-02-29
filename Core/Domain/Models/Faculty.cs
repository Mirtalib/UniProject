using Domain.Models.Common;

namespace Domain.Models;

public class Faculty : Entity
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public string UniversityId { get; set; }
    public List<string> SpecialtyIds { get; set; } = new List<string>();
}