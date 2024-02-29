using Domain.Models;

namespace Application.Models.DTOs.SpecialtyDTOs;

public class CreateSpecialtyDto
{
    public string Name { get; set; }
    public string FacultyId { get; set; }
}
