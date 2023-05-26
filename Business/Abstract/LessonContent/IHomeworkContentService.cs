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
    public interface IHomeworkContentService
    {

        IResult Add(IFormFile file, HomeworkContent homeworkContent);
        IDataResult<List<HomeworkContent>> GetAll();
        IDataResult<HomeworkContent> GetById(int id);
        IResult Update(IFormFile file, HomeworkContent homeworkContent);
        IResult Delete(HomeworkContent homeworkContent);
    }
}
