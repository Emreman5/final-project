using Core.Utilities.Abstract;
using Entities.LessonContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Abstract.LessonContent
{
    public interface ILearningOutComeService
    {

        IResult Add(LearningOutCome learningOutCome);
        IDataResult<List<LearningOutCome>> GetAll();
        IDataResult<LearningOutCome> GetById(int id);
        IResult Update(LearningOutCome learningOutCome);
        IResult Delete(LearningOutCome learningOutCome);
        IDataResult<LearningOutComeDetailsDto> GetLearningOutComeDetails(int lernOutComeId);
    }
}
