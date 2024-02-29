using Application.Models.DTOs.DepartmentDTOs;
using Application.Models.DTOs.FacultyDTOs;
using Application.Models.DTOs.GroupDTOs;
using Application.Models.DTOs.SpecialtyDTOs;
using Application.Models.DTOs.StudentDTOs;
using Application.Models.DTOs.TecherDTOs;
using Application.Models.DTOs.UniversityDTOs;
using Domain.Models;

namespace Application.Services.IUserService;

public interface IAdminService
{

    #region StudentFunction
    Task<bool> RegisterStudent(RegisterStudentDto studentDto);
    //Task<?> ViewAllStudent(?);
    //Task<bool> DeleteStudent(DeleteTeacherDto teacherDto);
    //Task<?> GetStudent(?);
    #endregion


    #region TeacherFunction
    Task<bool> RegisterTeacher(RegisterTeacherDto teacherDto);
    //Task<bool> DeleteTeacher(DeleteTeacherDto teacherDto);
    //Task<? GetTeacher(?);
    //Task<? ViewAllTeacher(?);
    #endregion


    #region UniversityFunction
    Task<bool> CreateUniversity(CreateUniversityDto universityDto);
   
    Task<bool> RemoveUniversity(RemoveUniversityDto removeUniversity);
    
    Task<bool> UpdateUniversity(UpdateUniversityDto updateUniversity);

    Task<List<ViewUniversityDto>> ViewAllUniversity();

    Task<ViewUniversityDto> GetUniversityId(string Id);


    #endregion


    #region FacultyFunction
    Task<bool> CreateFaculty(CreateFacultyDto facultyDto);

    Task<bool> UpdateFaculty(UpdateFacultyDto updateFaculty);

    Task<List<ViewFacultyDto>> ViewAllFacultyFromUniversityId(string Id);

    Task<ViewFacultyDto> GetFacultyId(string Id);

    Task<bool> RemoveFaculty(RemoveFacultyDto facultyDto);

    Task<bool> RemoveAllFacultyFromUniverstyId(string Id);


    #endregion


    #region SpecialtyFunction
    Task<bool> CreateSpecialty(CreateSpecialtyDto specialtyDto);
    
    Task<ViewSpecialtyDto> GetSpecialty(string Id);

    Task<List<ViewSpecialtyDto>> ViewAllSpecialtyFromFacultyId(string Id);

    Task<bool> RemoveSpecialty(RemoveSpecialtyDto specialtyDto);

    Task<bool> RemoveAllSpecialtyFromFacultyId(string Id);

    Task<bool> UpdateSpecialty(UpdateSpecialtyDto specialtyDto);

    #endregion


    #region GroupFunction
    
    Task<bool> CreateGroup(CreateGroupDto groupDto);
    
    Task<bool> UpdateGroup(UpdateGroupDto groupDto);
    
    Task<bool> RemoveGroup(RemoveGroupDto groupDto);
    
    Task<bool> RemoveAllGroupFromSpecialty(string Id);
    
    Task<ViewGroupDto> GetGroup(string Id);
    
    Task<List<ViewGroupDto>> ViewAllGroupFromSpecialtyId(string Id);
    #endregion


    #region DepartmentFunction
    Task<bool> CreateDepartment(CreateDepartmentDto departmentDto);

    Task<bool> UpdateDepartment(UpdateDepartmentDto departmentDto);

    Task<bool> RemoveDepartment(RemoveDepartmentDto departmentDto);
    
    Task<bool> RemoveAllDepartmentFromUniversityId(string Id);
    Task<List<ViewDepartmentDto>> ViewAllDepartmentFromUniversityId(string Id);

    Task<ViewDepartmentDto> ViewDepartment(string Id);


    #endregion

}
