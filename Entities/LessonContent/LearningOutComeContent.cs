using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class LearningOutComeContent:IEntity
    {
        public int Id { get; set; }
        public int LearningOutComeId { get; set; }
        public string SubstanceName { get; set; }
        public string SubstanceContent { get; set; }
        public int? MidtermExamQuestionId { get; set; }
        public int? FinalExamQuestionId { get; set; }
        public int? ProjectContentId { get; set; }
        public int? HomeworkContentId { get; set; }
        public int? ApplicationContentId { get; set; }
    }
}
