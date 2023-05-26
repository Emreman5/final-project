using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.LessonContent;

namespace Entities.DTOs
{
    public class MidtermExamDetailsDto
    {
        public string MidtermExamName { get; set; }
        public List<MidtermQuestion> MidtermExamQuestions { get; set; }
        public string Description { get; set; }
    }

    public class MidtermQuestion
    {
        public string QuestionName { get; set; }
        public string? ImagePath { get; set; }
        public string? QuestionContent { get; set; }
    }
}
