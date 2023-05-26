using Core.Utilities.Abstract;
using Entities;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IResult Add(Lesson lesson);
        IDataResult<List<Lesson>> GetAll();
        IDataResult<Lesson> GetById(int id);
        IResult Update(Lesson lesson);
        IResult Delete(Lesson lesson);
    }
}