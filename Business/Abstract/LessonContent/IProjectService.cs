using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities.LessonContent;

namespace Business.Abstract.LessonContent
{
    public interface IProjectService
    {
        IResult Add(Project project);
        IDataResult<List<Project>> GetAll();
        IDataResult<Project> GetById(int id);
        IResult Update(Project project);
        IResult Delete(Project project);
    }
}
