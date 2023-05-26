using Entities.LessonContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ApplicationDetailsDto
    {
        public string ApplicationName { get; set; }
        public List<ApplicationContentDisplay> ApplicationContents { get; set; }
        public string Description { get; set; }
    }

    public class ApplicationContentDisplay
    {
        public string QuestionName { get; set; }
        public string? ImagePath { get; set; }
        public string? QuestionContent { get; set; }
    }
}
