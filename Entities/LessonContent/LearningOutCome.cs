using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class LearningOutCome:IEntity
    {
        public int Id { get; set; }
        public string LearningOutComeName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
