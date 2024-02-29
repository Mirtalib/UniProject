using Application.Models.DTOs.DepartmentDTOs;
using Application.Models.DTOs.GroupDTOs;
using Application.Models.DTOs.LessonDTOs;
using Application.Models.DTOs.TecherDTOs;
using Application.Repositories;
using Application.Services.IUserService;
using Persistence.Repositories;
using System.Runtime.CompilerServices;

namespace Infrastructure.Services.UserService;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork unitOfWork;

    public TeacherService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ViewDepartmentDto> GetMyDepartment(string Id)
    {
        var teacher = await unitOfWork.ReadTeacherRepository.GetAsync(Id);
        if (teacher is null)
            throw new NullReferenceException();

        var department = await unitOfWork.ReadDepartmentRepository.GetAsync(teacher.DepartmentId);
        if (department is null)
            throw new NullReferenceException();


        var departmentDto = new ViewDepartmentDto
        {
            Name = department.Name,
            CreateTime = department.CreateDate,
            TeacherName = department.TeacherIds
        };

        return departmentDto;
    }

    public async Task<List<ViewGroupDto>> GetMyGroups(string Id)
    {
        //var teacher = await unitOfWork.ReadTeacherRepository.GetAsync(Id);
        //if (teacher is null)
        //    throw new NullReferenceException();

        //List<ViewGroupDto> groups = new List<ViewGroupDto>();
        //foreach (var item in teacher.GroupIds)
        //{
        //    var group = await unitOfWork.ReadGroupRepository.GetAsync(x => x.Id == item.ToString());

        //    groups.Add(new ViewGroupDto { 
        //        Name = group.Name

            
        //    });
        //}

        throw new NotImplementedException();
    }

    public Task<List<ViewLessonDto>> GetMyLessons(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<ViewTeacherProfileDto> GetMyProfile(string Id)
    {
        throw new NotImplementedException();
    }
}
