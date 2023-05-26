using Entities.LessonContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class HomeworkDetailsDto
    {
        public string HomeworkName { get; set; }
        public List<HomeworkContentDisplay> HomeworkContents { get; set; }
        public string Description { get; set; }
    }

    public class HomeworkContentDisplay
    {
        public string QuestionName { get; set; }
        public string? ImagePath { get; set; }
        public string? QuestionContent { get; set; }
    }
}
