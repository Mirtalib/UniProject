using Application.Models.DTOs.DepartmentDTOs;
using Application.Models.DTOs.FacultyDTOs;
using Application.Models.DTOs.GroupDTOs;
using Application.Models.DTOs.SpecialtyDTOs;
using Application.Models.DTOs.StudentDTOs;
using Application.Models.DTOs.TecherDTOs;
using Application.Models.DTOs.UniversityDTOs;
using Application.Repositories;
using Application.Services.UserService;
using Domain.Models;


namespace Infrastructure.Services.UserService;

public class AdminService : IAdminService
{

    private readonly IUnitOfWork unitOfWork;

    public AdminService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }



    #region University Function

    public async Task<bool> CreateUniversity(CreateUniversityDto universityDto)
    {
        var universityes = await unitOfWork.ReadUniversityRepository.GetAsync(uni => universityDto.Name.ToLower() == uni.Name.ToLower());
        if (universityes is not null)
            throw new NullReferenceException("There is a University with this name, choose another name");


        var university = new University
        {
            Id = Guid.NewGuid().ToString(),
            Name = universityDto.Name,
            CreateDate = DateTime.Now,
        };

        await unitOfWork.WriteUniversityRepository.AddAsync(university);
        await unitOfWork.WriteUniversityRepository.SaveChangesAsync();

        return true;
    }

    public async Task<List<ViewUniversityDto>> ViewAllUniversity()
    {

        List<ViewUniversityDto> universities = new();
        foreach (var item in unitOfWork.ReadUniversityRepository.GetAll())
        {
            if (item != null)
            {
                var facultiesname = new List<string>();

                foreach (var id in item.FacultyIds)
                {
                    var faculty = await GetFacultyId(id);
                    facultiesname.Add(faculty.Name);
                }

                universities.Add(new ViewUniversityDto
                {
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    CreateTime = item.CreateDate,
                    Faculty = facultiesname
                });
            }
        }
        return universities;
    }

    public async Task<ViewUniversityDto> GetUniversityId(string Id)
    {

        var selectUni = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == Id);

        if (selectUni is null)
            throw new NullReferenceException("There is no such university");

        var facultiesname = new List<string>();
        foreach (var id in selectUni.FacultyIds)
        {
            var faculty = await GetFacultyId(id);
            facultiesname.Add(faculty.Name);
        }

        var university = new ViewUniversityDto
        {
            Id = selectUni.Id,
            Name = selectUni.Name,
            CreateTime = selectUni.CreateDate,
            Faculty = facultiesname
        };

        return university;
    }

    public async Task<bool> UpdateUniversity(UpdateUniversityDto updateUniversity)
    {

        var university = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == updateUniversity.Id);

        if (university is null)
            throw new NullReferenceException("There is no such university");

        university.Name = updateUniversity.Name;

        unitOfWork.WriteUniversityRepository.Update(university);

        await unitOfWork.WriteUniversityRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveUniversity(RemoveUniversityDto removeUniversity)
    {
        var university = await unitOfWork
            .ReadUniversityRepository
            .GetAsync(uni => uni.Id == removeUniversity.Id);

        if (university is null)
            throw new NullReferenceException("There is no such university");

        await RemoveAllFacultyFromUniverstyId(university.Id);

        unitOfWork.WriteUniversityRepository.Remove(university);

        await unitOfWork.WriteUniversityRepository.SaveChangesAsync();
        return true;
    }

    #endregion


    #region Faculty Function
    public async Task<bool> CreateFaculty(CreateFacultyDto facultyDto)
    {

        var faculties = await unitOfWork.ReadFacultyRepository.GetAsync(faculty => facultyDto.Name.ToLower() == faculty.Name.ToLower());

        if (faculties != null)
            throw new NullReferenceException("There is a Faculty with this name, choose another name");


        var university = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == facultyDto.UniId);

        if (university == null)
            throw new NullReferenceException("There is no such university");


        var faculty = new Faculty
        {
            Id = Guid.NewGuid().ToString(),
            Name = facultyDto.Name,
            CreateDate = DateTime.Now,
            UniversityId = university.Id
        };

        university.FacultyIds.Add(faculty.Id);

        unitOfWork.WriteUniversityRepository.Update(university);
        await unitOfWork.WriteFacultyRepository.AddAsync(faculty);


        await unitOfWork.WriteFacultyRepository.SaveChangesAsync();
        await unitOfWork.WriteUniversityRepository.SaveChangesAsync();

        return true;

    }

    public async Task<List<ViewFacultyDto>> ViewAllFacultyFromUniversityId(string Id)
    {
        var university = await unitOfWork.ReadUniversityRepository.GetAsync(uni=> uni.Id == Id);
        if (university is null)
            throw new NullReferenceException("There is no such university");
        

        List<ViewFacultyDto> faculties = new();
        foreach (var item in unitOfWork.ReadFacultyRepository.GetWhere(faculty=> faculty.UniversityId == university.Id))
        {
            if (item != null)
            {
                faculties.Add(new ViewFacultyDto { Id = item.Id.ToString(), Name = item.Name , CreateTime = item.CreateDate });
            }
        }
        return faculties;
    }

    public async Task<ViewFacultyDto> GetFacultyId(string Id)
    {

        var selectfaculty = await unitOfWork.ReadFacultyRepository.GetAsync(fac => fac.Id == Id);
        if (selectfaculty is null)
            throw new NullReferenceException("There is no such faculty");

        var faculty = new ViewFacultyDto
        {
            Id = selectfaculty.Id.ToString(),
            CreateTime = selectfaculty.CreateDate,
            Name = selectfaculty.Name
        };
        
        var specialtes = unitOfWork.ReadSpecialtyRepository.GetWhere(x=> x.FacultyId ==faculty.Id);
        foreach (var item in specialtes)
        {
            if (item is not null)
                faculty.Specialties.Add(item.Name);
        }

        return faculty;
    }

    public async Task<bool> UpdateFaculty(UpdateFacultyDto updateFaculty)
    {
        var faculty = await unitOfWork.ReadFacultyRepository.GetAsync(fac => fac.Id == updateFaculty.Id);

        if (faculty is null)
            throw new NullReferenceException("There is no such faculty");

        faculty.UniversityId = updateFaculty.UniversityId;
        faculty.Name = updateFaculty.Name;

        unitOfWork.WriteFacultyRepository.Update(faculty);

        await unitOfWork.WriteFacultyRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveFaculty(RemoveFacultyDto facultyDto)
    {
        var faculty = await unitOfWork.ReadFacultyRepository.GetAsync(fac => fac.Id == facultyDto.Id);

        if (faculty is null)
            throw new NullReferenceException("There is no such faculty");

        await RemoveAllSpecialtyFromFacultyId(faculty.Id);
        unitOfWork.WriteFacultyRepository.Remove(faculty);
        await unitOfWork.WriteFacultyRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAllFacultyFromUniverstyId(string Id)
    {

        var universty = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == Id);
        if (universty is null)
            throw new NullReferenceException("There is no such university");

        var facultes = unitOfWork.ReadFacultyRepository.GetWhere(faculty => faculty.UniversityId == universty.Id);

        if (facultes is null)
            throw new NullReferenceException("There is no faculty within the university");

        foreach (var faculty in facultes)
        {
            if (faculty is not null)
            {
                await RemoveAllSpecialtyFromFacultyId(faculty.Id);
                unitOfWork.WriteFacultyRepository.Remove(faculty);
            }
        }
        await unitOfWork.WriteFacultyRepository.SaveChangesAsync();
        return true;
    }

    #endregion


    #region Specialty Function
    public async Task<bool> CreateSpecialty(CreateSpecialtyDto specialtyDto)
    {

        var specialties = await unitOfWork.ReadSpecialtyRepository.GetAsync(faculty => specialtyDto.Name.ToLower() == faculty.Name.ToLower());

        if (specialties != null)
            throw new NullReferenceException("There is a  Specialty with this name, choose another name");


        var faculty = await unitOfWork.ReadFacultyRepository.GetAsync(faculty => specialtyDto.FacultyId == faculty.Id);

        if (faculty == null)
            throw new NullReferenceException("There is no such faculty");



        var specialty = new Specialty
        {
            Id = Guid.NewGuid().ToString(),
            Name = specialtyDto.Name,
            CreateTime = DateTime.Now,
            FacultyId = faculty.Id
        };
        faculty.SpecialtyIds.Add(specialty.Id);


        unitOfWork.WriteFacultyRepository.Update(faculty);
        await unitOfWork.WriteSpecialtyRepository.AddAsync(specialty);

        await unitOfWork.WriteSpecialtyRepository.SaveChangesAsync();
        await unitOfWork.WriteFacultyRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateSpecialty(UpdateSpecialtyDto specialtyDto)
    {

        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(spec => spec.Id == specialtyDto.Id);

        if (specialty == null)
            throw new NullReferenceException("There is no such specialty");


        specialty.Name = specialtyDto.Name;
        specialty.FacultyId = specialtyDto.FacultyId;

        unitOfWork.WriteSpecialtyRepository.Update(specialty);
        await unitOfWork.WriteSpecialtyRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveSpecialty(RemoveSpecialtyDto specialtyDto)
    {

        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(spec => spec.Id == specialtyDto.Id);

        if (specialty == null)
            throw new NullReferenceException("There is no such specialty");
        unitOfWork.WriteSpecialtyRepository.Remove(specialty);
        await unitOfWork.WriteSpecialtyRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAllSpecialtyFromFacultyId(string Id)
    {
        var faculty = await unitOfWork.ReadFacultyRepository.GetAsync(fac => fac.Id == Id);
        if (faculty is null)
            throw new NullReferenceException();

        var specialty = unitOfWork.ReadSpecialtyRepository.GetWhere(x => x.FacultyId == faculty.Id);

        foreach (var item in specialty)
        {

            if (item is not null)
            {
                await RemoveAllGroupFromSpecialty(item.Id);
                unitOfWork.WriteSpecialtyRepository.Remove(item);
            }
        }
        await unitOfWork.WriteSpecialtyRepository.SaveChangesAsync();
        return true;

    }

    public async Task<List<ViewSpecialtyDto>> ViewAllSpecialtyFromFacultyId(string Id)
    {
        var faculty = await unitOfWork.ReadFacultyRepository.GetAsync(faculty => Id == faculty.Id);

        if (faculty == null)
            throw new NullReferenceException("There is no such faculty");

        var specialtyes = new List<ViewSpecialtyDto>();
        foreach (var item in unitOfWork.ReadSpecialtyRepository.GetWhere(specialty=>specialty.FacultyId == Id))
        {
            if (item is not null)
                specialtyes.Add(new ViewSpecialtyDto { Id = item.Id, CreateTime = item.CreateTime, Name = item.Name  });
        }

        return specialtyes;
    }

    public async Task<ViewSpecialtyDto> GetSpecialty(string Id)
    {

        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(spec => spec.Id == Id);
        if (specialty is null)
            throw new NullReferenceException("There is no such specialty");
        var specialtyDto = new ViewSpecialtyDto();

        specialtyDto.Id = specialty.Id;
        specialtyDto.Name = specialty.Name;
        specialtyDto.CreateTime = specialty.CreateTime;

        var groups = unitOfWork.ReadGroupRepository.GetWhere(x=> x.SpecialtyId == specialty.Id);

        foreach (var item in groups)
        {
            if (item is not null)
                specialtyDto.GroupName.Add(item.Name);

        }


        return specialtyDto;
    }

    #endregion


    #region Group Function
    
    public async Task<bool> CreateGroup(CreateGroupDto groupDto)
    {

        if (await unitOfWork.ReadGroupRepository.GetAsync(group => group.Name == groupDto.Name) != null)
            throw new NullReferenceException("There is a Group with this name, choose another name");


        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(specialty => specialty.Id == groupDto.SpecialtyId);

        if (specialty == null)
            throw new NullReferenceException("There is no such specialty");

        DateTime firstDate = DateTime.Now;

        var group = new Group
        {
            Id = Guid.NewGuid().ToString(),
            Name = groupDto.Name,
            StartTime = DateTime.Now,
            EndTime = firstDate.AddYears(4),
            SpecialtyId = specialty.Id
        };
        specialty.GroupIds.Add(group.Id);

        unitOfWork.WriteSpecialtyRepository.Update(specialty);
        await unitOfWork.WriteGroupRepository.AddAsync(group);

        await unitOfWork.WriteGroupRepository.SaveChangesAsync();
        await unitOfWork.WriteSpecialtyRepository.SaveChangesAsync();


        return true;
    }

    public async Task<bool> UpdateGroup(UpdateGroupDto groupDto)
    {
        var group = await unitOfWork.ReadGroupRepository.GetAsync(group=> group.Id == groupDto.Id);
        if (group == null) 
            throw new NullReferenceException("There is no such group");

        group.Name = groupDto.Name;
        group.SpecialtyId = groupDto.SpecialtyId;

        unitOfWork.WriteGroupRepository.Update(group);
        
        await unitOfWork.WriteGroupRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveGroup(RemoveGroupDto groupDto)
    {
        var group = await unitOfWork.ReadGroupRepository.GetAsync(group=> group.Id == groupDto.Id);
        if (group == null)
            throw new NullReferenceException("There is no such group");

        unitOfWork.WriteGroupRepository.Remove(group);
        await unitOfWork.WriteGroupRepository.SaveChangesAsync();

        return true;
    } 

    public async Task<bool> RemoveAllGroupFromSpecialty(string Id)
    {
        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(x => x.Id == Id);
        if (specialty is null)
            throw new NullReferenceException("There is no such specialty");

        var group = unitOfWork.ReadGroupRepository.GetWhere(x => x.SpecialtyId == specialty.Id);

        foreach (var item in group)
        {
            if (item is not null)
                unitOfWork.WriteGroupRepository.Remove(item);
        }
        await unitOfWork.WriteGroupRepository.SaveChangesAsync();

        return true;
    }

    public async Task<ViewGroupDto> GetGroup(string Id)
    {
        var group = await unitOfWork.ReadGroupRepository.GetAsync(Id);

        if (group is null)
            throw new NullReferenceException("There is no such group");

        var groupDto = new ViewGroupDto();
        
        groupDto.Id = group.Id;
        groupDto.Name = group.Name;
        groupDto.StartTime = group.StartTime;
        groupDto.EndTime = group.EndTime;

        var students = unitOfWork.ReadStudentRepository.GetWhere(x => x.GroupId == group.Id);
        foreach (var item in students)
        {
            if (item is not null)
                groupDto.StudentsFullname.Add($"{item.Name} {item.Surname}");
        }
        return groupDto;
    }

    public async Task<List<ViewGroupDto>> ViewAllGroupFromSpecialtyId(string Id)
    {
        var specialty = await unitOfWork.ReadSpecialtyRepository.GetAsync(x => x.Id == Id);
        if (specialty is null)
            throw new NullReferenceException("There is no such specialty");

        var groups = new List<ViewGroupDto>();

        foreach (var item in unitOfWork.ReadGroupRepository.GetWhere(x=> x.SpecialtyId == Id))
        {
            if (item is not null)
            {
                groups.Add(new ViewGroupDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                });
            }
        }
        
        return groups;
    }

    #endregion


    #region Student Function

    public async Task<bool> RegisterStudent(RegisterStudentDto studentDto)
    {
        var group = await unitOfWork.ReadGroupRepository.GetAsync(studentDto.GroupId);
        if (group is null)
            throw new NullReferenceException("There is no such group");

        var student = new Student
        {
            Id = Guid.NewGuid().ToString(),
            Name = studentDto.Name,
            Surname = studentDto.Surname,
            FatherName = studentDto.FatherName,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            PasswordHash = studentDto.PasswordHash,
            BirthDate = studentDto.BirthDate,
            GroupId = group.Id,
        };
        group.StudentIds.Add(student.Id);

        await unitOfWork.WriteStudentRepository.AddAsync(student);
        unitOfWork.WriteGroupRepository.Update(group);

        await unitOfWork.WriteGroupRepository.SaveChangesAsync();
        await unitOfWork.WriteStudentRepository.SaveChangesAsync();

        return true;   
    }
    

    #endregion


    #region Department Function

    public async Task<bool> CreateDepartment(CreateDepartmentDto departmentDto)
    {
        if (await unitOfWork.ReadDepartmentRepository.GetAsync(department => departmentDto.Name.ToLower() == department.Name.ToLower()) != null)
            throw new NullReferenceException("There is a Department with this name, choose another name");

        var university = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == departmentDto.UniversityId);
        if (university == null)
            throw new NullReferenceException("There is no such university");


        var department = new Department
        {
            Id = Guid.NewGuid().ToString(),
            Name = departmentDto.Name,
            CreateDate = DateTime.Now,
            UniversityId = university.Id
        };

        university.DepartmentIds.Add(department.Id);

        unitOfWork.WriteUniversityRepository.Update(university);
        await unitOfWork.WriteDepartmentRepository.AddAsync(department);

        await unitOfWork.WriteDepartmentRepository.SaveChangesAsync();
        await unitOfWork.WriteUniversityRepository.SaveChangesAsync();


        return true;
    }

    public async Task<bool> RemoveDepartment(RemoveDepartmentDto departmentDto)
    {
        var department = await unitOfWork.ReadDepartmentRepository.GetAsync(x=> x.Id == departmentDto.Id);

        if (department is null)
            throw new NullReferenceException("There is no such department");

        unitOfWork.WriteDepartmentRepository.Remove(department);
        await unitOfWork.WriteDepartmentRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateDepartment(UpdateDepartmentDto departmentDto)
    {
        var department = await unitOfWork.ReadDepartmentRepository.GetAsync(x => x.Id == departmentDto.Id);
        if (department is null)
            throw new NullReferenceException("There is no such department");

        department.Name = departmentDto.Name;
        department.CreateDate = departmentDto.CreateDate;
        department.UniversityId = departmentDto.UniversityId;

        unitOfWork.WriteDepartmentRepository.Update(department);
        await unitOfWork.WriteDepartmentRepository.SaveChangesAsync();
        
        return true;
    }

    public async Task<List<ViewDepartmentDto>> ViewAllDepartmentFromUniversityId(string Id)
    {
        var university = await unitOfWork.ReadUniversityRepository.GetAsync(uni => uni.Id == Id);
        if (university is null)
            throw new NullReferenceException("There is no such university");

        var departments = unitOfWork.ReadDepartmentRepository.GetWhere(x => x.UniversityId == Id);
        if (departments is null)
            throw new NullReferenceException("There is no such department");

        var departmentDtos = new List<ViewDepartmentDto>();
        foreach (var item in departments)
        {
            if (item is not null)
                departmentDtos.Add(new ViewDepartmentDto { Id = item.Id, Name = item.Name, CreateTime = item.CreateDate });
        }

        return departmentDtos;
    }

    public async Task<ViewDepartmentDto> ViewDepartment(string Id)
    {
        var department = await unitOfWork.ReadDepartmentRepository.GetAsync(x=> x.Id == Id);
        if (department is null)
            throw new NullReferenceException("There is no such department");

        var departmentDto = new ViewDepartmentDto();
        departmentDto.Id = department.Id;
        departmentDto.Name = department.Name;
        departmentDto.CreateTime = department.CreateDate;


        var teachers = unitOfWork.ReadTeacherRepository.GetWhere(x => x.DepartmentId == department.Id);
        foreach (var item in teachers)
        {
            if (item is not null)
                departmentDto.TeacherName.Add($"{item.Name} {item.Surname}");   
        }

        return departmentDto;
    }

    public async Task<bool> RemoveAllDepartmentFromUniversityId(string Id)
    {

        var uni = await unitOfWork.ReadUniversityRepository.GetAsync(x=>x.Id == Id);

        if (uni is null)
           throw new NullReferenceException("There is no such university");

        var departments = unitOfWork.ReadDepartmentRepository.GetWhere(x => x.UniversityId == uni.Id);

        if (departments is null)
            throw new NullReferenceException("There is no such department");

        foreach (var item in departments)
        {
            if(item is not null)
                unitOfWork.WriteDepartmentRepository.Remove(item);
        }
        await unitOfWork.WriteDepartmentRepository.SaveChangesAsync();

        return true;
    }

    #endregion


    #region TeacherFunction
    public async Task<bool> RegisterTeacher(RegisterTeacherDto teacherDto)
    {
        var department = await unitOfWork.ReadDepartmentRepository.GetAsync(teacherDto.DepartmentId);
        if (department is null)
            throw new NullReferenceException("There is no such department");

        var teacher = new Teacher
        {
            Id = Guid.NewGuid().ToString(),
            Name = teacherDto.Name,
            Surname = teacherDto.Surname,
            FatherName = teacherDto.FatherName,
            Email = teacherDto.Email,
            PhoneNumber = teacherDto.PhoneNumber,
            PasswordHash = teacherDto.PasswordHash,
            BirthDate = teacherDto.BirthDate,
            DepartmentId = department.Id,
        };

        department.TeacherIds.Add(teacher.Id);


        await unitOfWork.WriteTeacherRepository.AddAsync(teacher);
        unitOfWork.WriteDepartmentRepository.Update(department);

        await unitOfWork.WriteDepartmentRepository.SaveChangesAsync();
        await unitOfWork.WriteTeacherRepository.SaveChangesAsync();
        return true;
    }
    #endregion


}
