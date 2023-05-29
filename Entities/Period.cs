using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities
{
    public class Period:IEntity
    {
        public int  Id { get; set; }
        public string PeriodName { get; set; }
      

    }
}
