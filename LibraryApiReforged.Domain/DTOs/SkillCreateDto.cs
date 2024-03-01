using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApiReforged.Domain.DTOs
{
    public class SkillCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MasteryLevel { get; set; }
    }
}
