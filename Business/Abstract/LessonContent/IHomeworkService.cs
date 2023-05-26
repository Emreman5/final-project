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
    public interface IHomeworkService
    {
        IResult Add(Homework homework);
        IDataResult<List<Homework>> GetAll();
        IDataResult<Homework> GetById(int id);
        IResult Update(Homework homework);
        IResult Delete(Homework homework);
        IDataResult<HomeworkDetailsDto> GetHomeworkDetails(int homeworkId);
    }
}
