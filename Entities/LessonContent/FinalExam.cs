using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class FinalExam:IEntity
    {
        public int Id { get; set; }
        public string FinalExamName { get; set; }
        public DateTime FinalExamTime { get; set; }
        public double FinalExamPercentage { get; set; }
        public string Description { get; set; }
    }
}
