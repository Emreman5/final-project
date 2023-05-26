using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.LessonContent
{
    public class Application:IEntity
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ApplicationTime { get; set; }
        public string Description { get; set; }
        public double ApplicationPercentage { get; set; }
    }
}
