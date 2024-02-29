using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.GroupDTOs
{
    public class UpdateGroupDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SpecialtyId { get; set; }
    }
}
