using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class Project:IEntity
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectDate { get; set; }
        public double ProjectPercentage { get; set; }
        public string Description { get; set; }
    }
}
