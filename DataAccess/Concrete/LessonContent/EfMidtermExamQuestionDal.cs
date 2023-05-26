using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.LessonContent;
using Entities.LessonContent;

namespace DataAccess.Concrete.LessonContent
{
    public class EfMidtermExamQuestionDal:EfRepositoryBase<MidtermExamQuestion,ProjectDbContext>,IMidtermExamQuestionDal
    {
    }
}
