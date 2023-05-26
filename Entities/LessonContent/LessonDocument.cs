using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class LessonDocument:IEntity
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public string DocumanName { get; set; }
        public string? ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
