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
    public interface IFinalExamService
    {
        IResult Add(FinalExam finalExam);
        IDataResult<List<FinalExam>> GetAll();
        IDataResult<FinalExam> GetById(int id);
        IResult Update(FinalExam finalExam);
        IResult Delete(FinalExam finalExam);
        IDataResult<FinalExamDetailsDto> GetFinalExamDetails(int finalExamId);
    }
}