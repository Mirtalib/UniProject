using Domain.Models;

namespace Application.Models.DTOs.GroupDTOs;

public class CreateGroupDto
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string SpecialtyId { get; set; }

}
