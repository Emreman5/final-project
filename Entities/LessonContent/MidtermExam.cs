using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class MidtermExam:IEntity
    {
        public int Id { get; set; }
        public string MidtermExamName { get; set; }
        public DateTime MidtermExamTime { get; set; }
        public double MidtermExamPercentage { get; set; }
        public string Description { get; set; }
    }
}
