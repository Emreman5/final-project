using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities.DTOs;
using Entities.LessonContent;

namespace Business.Abstract.LessonContent
{
    public interface IMidtermExamService
    {
        IResult Add(MidtermExam midtermExam);
        IDataResult<List<MidtermExam>> GetAll();
        IDataResult<MidtermExam> GetById(int id);
        IResult Update(MidtermExam midtermExam);
        IResult Delete(MidtermExam midtermExam);
        IDataResult<MidtermExamDetailsDto> GetMidtermExamDetails(int midtermExId);
    }
}