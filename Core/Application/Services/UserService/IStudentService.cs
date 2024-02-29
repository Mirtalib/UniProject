using Application.Models.DTOs;
using Application.Models.DTOs.LessonDTOs;
using Application.Models.DTOs.StudentDTOs;
using Domain.Models;

namespace Application.Services.UserService;

public interface IStudentService
{
    Task<ViewProfileDto> ViewProfile();
    Task<ViewLessonDto> ViewLessons(string Id);
    public IEnumerable<MarkDto> ViewMarks();
    Task<AbsentDto> ViewAbsents();
    IEnumerable<Exam> ViewExams();
    public Group ViewGroupInfo();
}
