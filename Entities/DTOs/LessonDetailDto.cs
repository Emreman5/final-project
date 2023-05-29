using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LessonDetailDto
    {
        public int LessonId { get; set; }
        public string LecturerName { get; set; }
        public string PeriodName { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
    }
}
