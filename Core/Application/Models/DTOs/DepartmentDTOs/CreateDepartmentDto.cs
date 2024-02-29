using Domain.Models;

namespace Application.Models.DTOs.DepartmentDTOs;

public class CreateDepartmentDto
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public string UniversityId { get; set; }
}


