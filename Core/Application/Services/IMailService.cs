namespace Application.Services;

public interface IMailService
{
    public void SendOverLimitMessage(string email);
    public void SendExamFailMessage(string email); 
    public void NotifyOtherNew(string email, string message);
}
