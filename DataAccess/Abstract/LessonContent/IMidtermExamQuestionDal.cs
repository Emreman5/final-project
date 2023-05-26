using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.LessonContent;

namespace DataAccess.Abstract.LessonContent
{
    public interface IMidtermExamQuestionDal:IEntityRepository<MidtermExamQuestion>
    {
    }
}
