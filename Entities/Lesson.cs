using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.LessonContent;

namespace Entities
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public int? LecturerId { get; set; }
        public int? PeriodId { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set;}
    }
}
