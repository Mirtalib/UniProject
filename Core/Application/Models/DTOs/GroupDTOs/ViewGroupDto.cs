using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.GroupDTOs
{
    public class ViewGroupDto
    {
        public string Id { get; set;}
        public string Name { get; set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> StudentsFullname { get; set; }
    }
}
