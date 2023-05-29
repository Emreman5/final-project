using Core.Utilities.Abstract;
using Entities;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IResult Add(Lesson lesson);
        IDataResult<List<Lesson>> GetAll();
        IDataResult<Lesson> GetById(int id);
        IResult Update(Lesson lesson);

        IDataResult<List<LessonDetailDto>> GetAllLessonsWithDetail();
        IDataResult<List<LessonDetailDto>> GetAllLessonsWithDetailById(string id);

        IResult Delete(int lessonId);
    }
}