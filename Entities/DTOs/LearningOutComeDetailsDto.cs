using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.LessonContent;

namespace Entities.DTOs
{
    public class LearningOutComeDetailsDto
    {
        public string LearningOutComeName { get; set; }
        public List<LearningOutComeContentDisplay> LearningOutComeContents { get; set;}
        public string Description { get; set; }
    }

    public class LearningOutComeContentDisplay
    {
        public string SubstanceName { get; set; }
        public string SubstanceContent { get; set; }
    }
}
