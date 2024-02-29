using Application.Models.DTOs;
using Application.Models.DTOs.LessonDTOs;
using Application.Models.DTOs.StudentDTOs;
using Application.Repositories;
using Application.Services.IUserService;
using Domain.Models;
using Persistence.Context;

namespace Infrastructure.Services.UserService;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork; 

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<AbsentDto> ViewAbsents()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exam> ViewExams()
    {
        throw new NotImplementedException();
    }

    public Group ViewGroupInfo()
    {
        throw new NotImplementedException();
    }

    public Task<ViewLessonDto> ViewLessons(string Id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MarkDto> ViewMarks()
    {
        throw new NotImplementedException();
    }

    public Task<ViewProfileDto> ViewProfile()
    {
        throw new NotImplementedException();
    }
}
