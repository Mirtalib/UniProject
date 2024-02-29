using Domain.Models.Common;

namespace Domain.Models;

public class Exam : Entity
{
    public byte EntranceScore { get; set; } 
    public byte ExamScore { get; set;}
    public DateTime ExamDate { get; set; }
    public string LessonId { get; set; }
}