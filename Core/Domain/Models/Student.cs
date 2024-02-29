using Domain.Models.Common;

namespace Domain.Models;

public class Student :  User
{
    public KeyValuePair<string , byte> AbsentCountForLesson { get; set; }  = new KeyValuePair<string , byte>();
    public KeyValuePair<string, List<byte>> MarkForLesson { get; set; } = new KeyValuePair<string, List<byte>>();
    public string GroupId { get; set; }
}
