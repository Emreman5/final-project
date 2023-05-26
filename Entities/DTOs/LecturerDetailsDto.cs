using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class LecturerDetailsDto:IDto
    {
        public string Appellation { get; set; }
        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
    }
}
