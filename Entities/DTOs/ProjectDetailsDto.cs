using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.LessonContent;

namespace Entities.DTOs
{
    public class ProjectDetailsDto
    {
        public string ProjectName { get; set; }
        public List<ProjectContentDisplay> ProjectContents { get; set; }
        public string Description { get; set; }
    }

    public class ProjectContentDisplay
    {
        public string QuestionName { get; set; }
        public string? ImagePath { get; set; }
        public string? QuestionContent { get; set; }
    }
}
