using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.LessonContent;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract.LessonContent;
using Entities.DTOs;
using Entities.LessonContent;

namespace Business.Concrete.LeessonContent
{
    public class ApplicationManager:IApplicationService
    {
        private IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }
        public IResult Add(Application application)
        {
            _applicationDal.Add(application);
            return new SuccesResult(Messages.AddedApplication);
        }

        public IDataResult<List<Application>> GetAll()
        {
            return new SuccessDataResult<List<Application>>(_applicationDal.GetAll(), Messages.ListedApplications);
        }

        public IDataResult<Application> GetById(int id)
        {
            var result = _applicationDal.GetAll().SingleOrDefault(a => a.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Application>(_applicationDal.Get(a => a.Id == id));
            }
            return new ErrorDataResult<Application>(Messages.InvalidApplication);
        }

        public IResult Update(Application application)
        {
            var result = _applicationDal.GetAll().SingleOrDefault(a => a.Id == application.Id);
            if (result != null)
            {
                _applicationDal.Update(application);
                return new SuccesResult(Messages.UpdatedApplication);
            }
            return new ErrorResult(Messages.InvalidApplication);
        }

        public IResult Delete(Application application)
        {

            var result = _applicationDal.GetAll().SingleOrDefault(a => a.Id == application.Id);
            if (result != null)
            {
                _applicationDal.Delete(application);
                return new SuccesResult(Messages.DeletedApplication);
            }
            return new ErrorResult(Messages.InvalidApplication);
        }

        public IDataResult<ApplicationDetailsDto> GetApplicationDetails(int applicationId)
        {
            var result = _applicationDal.GetApplicationDetails(applicationId);
            if (result != null)
            {
                return new SuccessDataResult<ApplicationDetailsDto>(_applicationDal.GetApplicationDetails(applicationId));
            }

            return new ErrorDataResult<ApplicationDetailsDto>(Messages.InvalidApplication);
        }
    }
}
