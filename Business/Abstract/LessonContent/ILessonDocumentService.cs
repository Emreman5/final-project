using Core.Utilities.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.LessonContent;

namespace Business.Abstract.LessonContent
{
    public interface ILessonDocumentService
    {

        IResult Add(IFormFile file, LessonDocument lessonDocument);
        IDataResult<List<LessonDocument>> GetAll();
        IDataResult<LessonDocument> GetById(int id);
        IResult Update(IFormFile file, LessonDocument lessonDocument);
        IResult Delete(LessonDocument lessonDocument);
    }
}
