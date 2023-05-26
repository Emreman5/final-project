using Core.Utilities.Abstract;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract.LessonContent
{
    public interface IMidtermExamQuestionService
    {
        IResult Add(IFormFile file,MidtermExamQuestion  question);
        IDataResult<List<MidtermExamQuestion>> GetAll();
        IDataResult<MidtermExamQuestion> GetById(int id);
        IResult Update(IFormFile file,MidtermExamQuestion question);
        IResult Delete(MidtermExamQuestion question);
    }
}