using Core.Utilities.Abstract;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.LessonContent
{
    public interface ILearningOutComeContentService
    {
        IResult Add(LearningOutComeContent learningOutComeContent);
        IDataResult<List<LearningOutComeContent>> GetAll();
        IDataResult<LearningOutComeContent> GetById(int id);
        IResult Update(LearningOutComeContent learningOutComeContent);
        IResult Delete(LearningOutComeContent learningOutComeContent);
    }
}
