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
    public interface IApplicationContentService
    {
        IResult Add(IFormFile file, ApplicationContent applicationContent);
        IDataResult<List<ApplicationContent>> GetAll();
        IDataResult<ApplicationContent> GetById(int id);
        IResult Update(IFormFile file, ApplicationContent applicationContent);
        IResult Delete(ApplicationContent applicationContent);
    }
}
