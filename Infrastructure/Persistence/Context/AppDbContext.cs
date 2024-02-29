using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToContainer("Students");
        modelBuilder.Entity<Admin>().ToContainer("Admins");
        modelBuilder.Entity<University>().ToContainer("Universities");
        modelBuilder.Entity<Faculty>().ToContainer("Faculties");
        modelBuilder.Entity<Specialty>().ToContainer("Specialties");
        modelBuilder.Entity<Group>().ToContainer("Groups");
        modelBuilder.Entity<Teacher>().ToContainer("Teachers");
        modelBuilder.Entity<Department>().ToContainer("Departments");
        modelBuilder.Entity<Exam>().ToContainer("Exams");
        modelBuilder.Entity<Lesson>().ToContainer("Lessons");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<University>  Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Specialty> Specialties  { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
}
