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
    public interface IApplicationService
    {

        IResult Add(Application application);
        IDataResult<List<Application>> GetAll();
        IDataResult<Application> GetById(int id);
        IResult Update(Application application);
        IResult Delete(Application application);
        IDataResult<ApplicationDetailsDto> GetApplicationDetails(int applicationId);
    }
}
