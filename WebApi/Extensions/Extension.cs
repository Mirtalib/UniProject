using Application.Models.Config;
using Application.Repositories;
using Application.Repositories.IDepartmentRepository;
using Application.Repositories.IExamRepository;
using Application.Repositories.IFacultyRepository;
using Application.Repositories.IGroupRepository;
using Application.Repositories.ILessonRepository;
using Application.Repositories.ISpecialtyRepository;
using Application.Repositories.IStudentRepository;
using Application.Repositories.ITeacherRepository;
using Application.Repositories.IUniversityRepository;
using Application.Services.IUserService;
using Infrastructure.Services;
using Infrastructure.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.DepartmentRepository;
using Persistence.Repositories.ExamRepository;
using Persistence.Repositories.FacultyRepository;
using Persistence.Repositories.GroupRepository;
using Persistence.Repositories.LessonRepository;
using Persistence.Repositories.SpecialtyRepository;
using Persistence.Repositories.StudentRepository;
using Persistence.Repositories.TeacherRepository;
using Persistence.Repositories.UniversityRepository;

namespace WebApi.Extensions;

public static class Extension
{

    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var cosmos = new CosmosConfig();
        configuration.GetSection("Cosmos").Bind(cosmos);
        services.AddDbContext<AppDbContext>(op => op.UseCosmos(cosmos.Uri, cosmos.Key, cosmos.DatabaseName));
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ITeacherService, TeacherService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadUniversityRepository, ReadUniversityRepository>();
        services.AddScoped<IWriteUniversityRepository ,  WriteUniversityRepository>();

        services.AddScoped<IReadFacultyRepository, ReadFacultyRepository>();
        services.AddScoped<IWriteFacultyRepository , WriteFacultyRepository>();

        services.AddScoped<IReadSpecialtyRepository, ReadSpecialtyRepository>();
        services.AddScoped<IWriteSpecialtyRepository, WriteSpecialtyRepository>();

        services.AddScoped<IReadGroupRepository, ReadGroupRepository>();
        services.AddScoped<IWriteGroupRepository, WriteGroupRepository>();

        services.AddScoped<IReadStudentRepository, ReadStudentRepository>();
        services.AddScoped<IWriteStudentRepository, WriteStudentRepository>();

        services.AddScoped<IReadLessonRepository, ReadLessonRepository>();
        services.AddScoped<IWriteLessonRepository, WriteLessonRepository>();

        services.AddScoped<IReadExamRepository, ReadExamRepository>();
        services.AddScoped<IWriteExamRepository, WriteExamRepository>();

        services.AddScoped<IReadDepartmentRepository, ReadDepartmentRepository>();
        services.AddScoped<IWriteDepartmentRepository, WriteDepartmentRepository>();

        services.AddScoped<IReadTeacherRepository, ReadTeacherRepository>();
        services.AddScoped<IWriteTeacherRepository, WriteTeacherRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
