using Core.Utilities.Abstract;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;

namespace Business.Abstact.LessonContent
{
    public interface IFinalExamQuestionService
    {
        IResult Add(IFormFile file,FinalExamQuestion question);
        IDataResult<List<FinalExamQuestion>> GetAll();
        IDataResult<FinalExamQuestion> GetById(int id);
        IResult Update(IFormFile file,FinalExamQuestion  question);
        IResult Delete(FinalExamQuestion question);
    }
}