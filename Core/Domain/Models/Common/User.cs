namespace Domain.Models.Common;

public abstract class User : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public DateTime BirthDate { get; set; }
}
