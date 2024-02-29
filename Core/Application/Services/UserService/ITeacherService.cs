using Application.Models.DTOs.DepartmentDTOs;
using Application.Models.DTOs.GroupDTOs;
using Application.Models.DTOs.LessonDTOs;
using Application.Models.DTOs.TecherDTOs;
using Application.Models.DTOs.UniversityDTOs;

namespace Application.Services.UserService;

public interface ITeacherService
{
    #region Get
    Task<ViewDepartmentDto> GetMyDepartment(string Id);
    Task<List<ViewGroupDto>> GetMyGroups(string Id);
    Task<List<ViewLessonDto>> GetMyLessons(string Id);
    Task<ViewTeacherProfileDto> GetMyProfile(string Id);
    #endregion
}
