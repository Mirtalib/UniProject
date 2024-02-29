namespace Application.Models.DTOs.FacultyDTOs;

public class ViewFacultyDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public List<string> Specialties { get; set; }
}
