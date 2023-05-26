using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class Homework: IEntity
    {
        public int Id { get; set; }
        public string HomeworkName { get; set; }
        public DateTime HomeworkDate { get; set; }
        public double HomeworkPercentage { get; set; }
        public string Description { get; set; }
    }
}
