namespace Application.Models.DTOs.UniversityDTOs;

public class ViewUniversityDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public List<string> Faculty { get; set; }
}