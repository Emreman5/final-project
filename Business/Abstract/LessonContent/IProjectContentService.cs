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
    public interface IProjectContentService
    {
        IResult Add(IFormFile file, ProjectContent projectContent);
        IDataResult<List<ProjectContent>> GetAll();
        IDataResult<ProjectContent> GetById(int id);
        IResult Update(IFormFile file, ProjectContent projectContent);
        IResult Delete(ProjectContent projectContent);
    }
}
