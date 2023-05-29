using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities
{
    public class Lecturer:IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string CommunicationInformation { get; set; }
    }
}
