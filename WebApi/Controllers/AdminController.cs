using Microsoft.AspNetCore.Mvc;
using Application.Models.DTOs.UniversityDTOs;
using Application.Models.DTOs.FacultyDTOs;
using Application.Models.DTOs.GroupDTOs;
using Application.Models.DTOs.DepartmentDTOs;
using Application.Models.DTOs.SpecialtyDTOs;
using Application.Models.DTOs.StudentDTOs;
using Application.Models.DTOs.TecherDTOs;
using Application.Services.UserService;
using Domain.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{

    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }



    #region UniversityFunction

    [HttpPost("createUniversity")]
    public async Task<ActionResult> CreateUniversity(CreateUniversityDto universityDto)
    {
        try
        {
            if (universityDto is null)
                return BadRequest();

            if (await _adminService.CreateUniversity(universityDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("viewAllUniversity")]
    public async Task<ActionResult<List<ViewUniversityDto>>> ViewAllUniversity()
    {
        try
        {
            var allUni = await _adminService.ViewAllUniversity();
            if (allUni.Count == 0)
                return NotFound();
            return Ok(allUni);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getUniversityId")]
    public async Task<ActionResult<ViewUniversityDto>> GetUniversityId(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();
            var uni = await _adminService.GetUniversityId(id);
            return Ok(uni);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("updateUniversity")]
    public async Task<ActionResult> UpdateUniversity(UpdateUniversityDto universityDto)
    {
        try
        {
            if (await _adminService.UpdateUniversity(universityDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeUniversity")]
    public async Task<ActionResult> RemoveUniversity(RemoveUniversityDto universityDto)
    {
        try
        {
            if (await _adminService.RemoveUniversity(universityDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion



    #region Faculty Function

    [HttpPost("createFaculty")]
    public async Task<ActionResult> CreateFaculty(CreateFacultyDto facultyDto)
    {
        try
        {
            if (facultyDto is null)
                return BadRequest();
            if (await _adminService.CreateFaculty(facultyDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("viewAllFaculty")]
    public async Task<ActionResult> ViewAllFacultyFromUniversity(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var allFaculty = await _adminService.ViewAllFacultyFromUniversityId(Id);
            return Ok(allFaculty);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetFacultyId")]
    public async Task<ActionResult> GetFacultyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var faculty = await _adminService.GetFacultyId(Id);
            return Ok(faculty);
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.Message);
        }
    }

    [HttpPost("updateFaculty")]
    public async Task<ActionResult> UpdateFaculty(UpdateFacultyDto facultyDto)
    {
        try
        {
            if (facultyDto is null)
                return BadRequest();
            if (await _adminService.UpdateFaculty(facultyDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeFaculty")]
    public async Task<ActionResult> RemoveFaculty(RemoveFacultyDto facultyDto)
    {
        try
        {
            if (facultyDto is null)
                return BadRequest();
            if (await _adminService.RemoveFaculty(facultyDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeAllFacultyFromUniverstyId")]
    async Task<ActionResult> RemoveAllFacultyFromUniverstyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            if (await _adminService.RemoveAllFacultyFromUniverstyId(Id))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    #endregion



    #region Specialty Function
    [HttpPost("createSpecialty")]
    public async Task<ActionResult> CreateSpecialty(CreateSpecialtyDto specialtyDto)
    {
        try
        {
            if (specialtyDto is null)
                return BadRequest();
            if (await _adminService.CreateSpecialty(specialtyDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getSpecialty")]
    public async Task<ActionResult> GetSpecialty(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var specialty = await _adminService.GetSpecialty(Id);
            return Ok(specialty); 
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("updateSpecialty")]
    public async Task<ActionResult> UpdateSpecialty(UpdateSpecialtyDto specialtyDto)
    {
        try
        {
            if (specialtyDto is null)
                return BadRequest();

            if (await _adminService.UpdateSpecialty(specialtyDto))
                return Ok();
            return BadRequest();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("viewAllSpecialtyFromFacultyId")]
    public async Task<ActionResult> RemoveSpecialty(RemoveSpecialtyDto specialtyDto)
    {
        try
        {
            if (specialtyDto is null)
                return BadRequest();
            if (await _adminService.RemoveSpecialty(specialtyDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeAllSpecialtyFromFacultyId")]
    public async Task<ActionResult> RemoveAllSpecialtyFromFacultyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            if (await _adminService.RemoveAllSpecialtyFromFacultyId(Id))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("removeSpecialty")]
    public async Task<ActionResult> ViewAllSpecialtyFromFacultyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var specialty = await _adminService.ViewAllFacultyFromUniversityId(Id);
            return Ok(specialty);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion



    #region Group Function
    [HttpPost("createGroup")]
    public async Task<ActionResult> CreateGroup(CreateGroupDto groupDto)
    {
        try
        {
            if (groupDto == null)
                return BadRequest();

            if (await _adminService.CreateGroup(groupDto))
            {
                return Ok();
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("updateGroup")]
    public async Task<ActionResult> UpdateGroup(UpdateGroupDto groupDto)
    {
        try
        {
            if (groupDto == null)
                return BadRequest();
            if (await _adminService.UpdateGroup(groupDto))
                return Ok();
            return BadRequest();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeGroup")]
    public async Task<ActionResult> RemoveGroup(RemoveGroupDto groupDto)
    {
        try
        {
            if (groupDto == null)
                return BadRequest();
            if (await _adminService.RemoveGroup(groupDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeAllGroupFromSpecialtyId")]
    public async Task<ActionResult> RemoveAllGroupFromSpecialtyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            if (await _adminService.RemoveAllGroupFromSpecialty(Id))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getGroup")]
    public async Task<ActionResult> GetGroup(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var group = await _adminService.GetGroup(Id);
            return Ok(group);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("viewAllGroupFromSpecialtyId")]
    public async Task<ActionResult> ViewAllGroupFromSpecialtyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var group = await _adminService.ViewAllGroupFromSpecialtyId(Id);
            return Ok(group);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion



    #region Department Function
    [HttpPost("createDepartment")]
    public async Task<ActionResult> CreateDepartment(CreateDepartmentDto departmentDto)
    {
        try
        {
            if (departmentDto is null)
                return BadRequest();
            if (await _adminService.CreateDepartment(departmentDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("updateDepartment")]
    public async Task<ActionResult> UpdateDepartment(UpdateDepartmentDto departmentDto)
    {
        try
        {
            if (departmentDto is null)
                return BadRequest();
            if (await _adminService.UpdateDepartment(departmentDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeDepartment")]
    public async Task<ActionResult> RemoveDepartment(RemoveDepartmentDto departmentDto)
    {
        try
        {
            if (departmentDto is null)
                return BadRequest();
            if (await _adminService.RemoveDepartment(departmentDto))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("removeAllDepartmentFromUniverstyId")]
    public async Task<ActionResult> RemoveAllDepartmentFromUniverstyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            if (await _adminService.RemoveAllDepartmentFromUniversityId(Id))
                return Ok();
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("getDepartment")]
    public async Task<ActionResult> GetDepartment(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var department = await _adminService.ViewDepartment(Id);
            return Ok(department);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("viewAllDepartmentFromUniverstyId")]
    public async Task<ActionResult> ViewAllDepartmentFromUniverstyId(string Id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();
            var department = await _adminService.ViewAllDepartmentFromUniversityId(Id);
            return Ok(department);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion



    #region Teacher Function
    [HttpPost("registerTeacher")]
    public async Task<ActionResult> RegisterTeacher(RegisterTeacherDto request)
    {
        return Ok();
    }
    #endregion



    #region Student Function
    [HttpPost("addStudent")]
    public Task<bool> AddStudent(RegisterStudentDto request)
    {
        return _adminService.RegisterStudent(request);
    }
    #endregion



    #region Admin Function
    [HttpPost("registerAdmin")]
    public async Task<ActionResult> RegisterAdmin()
    {
        return Ok();
    }
    #endregion
}