using Domain.Models.Common;

namespace Domain.Models;

public class Group : Entity
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string SpecialtyId { get; set; }
    public List<string> StudentIds { get; set; } = new List<string>();
}

