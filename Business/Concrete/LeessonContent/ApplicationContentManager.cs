using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.LessonContent;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete.LeessonContent
{
    public class ApplicationContentManager:IApplicationContentService
    {
        private IApplicationContentDal _applicationContentDal;
        IFileHelper _fileHelper;

        public ApplicationContentManager(IApplicationContentDal applicationContentDal,IFileHelper fileHelper)
        {
            _applicationContentDal  = applicationContentDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ApplicationContent applicationContent)
        {
            if (applicationContent.QuestionContent == null)
            {
                applicationContent.ImagePath = _fileHelper.Upload(file, ImagePaths.ApplicationContentsPath);
            }
            applicationContent.Date = DateTime.Now;
            _applicationContentDal.Add(applicationContent);
            return new SuccesResult(Messages.AddedApplicationContent);
        }

        public IDataResult<List<ApplicationContent>> GetAll()
        {
            return new SuccessDataResult<List<ApplicationContent>>(_applicationContentDal.GetAll(), Messages.ListedApplicationContents);
        }

        public IDataResult<ApplicationContent> GetById(int id)
        {
            var result = _applicationContentDal.GetAll().SingleOrDefault(ac => ac.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<ApplicationContent>(_applicationContentDal.Get(ac => ac.Id == id));
            }

            return new ErrorDataResult<ApplicationContent>(Messages.InvalidApplicationContent);
        }

        public IResult Update(IFormFile file, ApplicationContent applicationContent)
        {
            var result = _applicationContentDal.GetAll().SingleOrDefault(ac => ac.Id == applicationContent.Id);
            if (result != null)
            {
                if (applicationContent.QuestionContent == null)
                {
                    var prevImagePath = result.ImagePath;
                    applicationContent.ImagePath = _fileHelper.Update(file, ImagePaths.ApplicationContentsPath + prevImagePath,ImagePaths.ApplicationContentsPath);
                }

                applicationContent.Date = DateTime.Now;
                _applicationContentDal.Update(applicationContent);
                return new SuccesResult(Messages.UpdatedApplicationContent);
            }

            return new ErrorResult(Messages.InvalidApplicationContent);
        }

        public IResult Delete(ApplicationContent applicationContent)
        {
            var result = _applicationContentDal.GetAll().SingleOrDefault(ac => ac.Id == applicationContent.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.ApplicationContentsPath + prevImagePath);
                _applicationContentDal.Delete(applicationContent);
                return new SuccesResult(Messages.DeletedApplicationContent);
            }

            return new ErrorResult(Messages.InvalidApplicationContent);
        }
    }
}
