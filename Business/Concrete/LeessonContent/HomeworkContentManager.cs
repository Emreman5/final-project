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
    public class HomeworkContentManager:IHomeworkContentService
    {
        private IHomeworkContentDal _homeworkContentDal;
        IFileHelper _fileHelper;
        public IResult Add(IFormFile file, HomeworkContent homeworkContent)
        {
            if (homeworkContent.QuestionContent == null)
            {
                homeworkContent.ImagePath = _fileHelper.Upload(file, ImagePaths.HomeworkContentsPath);
            }
            homeworkContent.Date = DateTime.Now;
            _homeworkContentDal.Add(homeworkContent);
            return new SuccesResult(Messages.AddedHomeworkContent);
        }

        public IDataResult<List<HomeworkContent>> GetAll()
        {
            return new SuccessDataResult<List<HomeworkContent>>(_homeworkContentDal.GetAll(), Messages.ListedHomeworkContent);
        }

        public IDataResult<HomeworkContent> GetById(int id)
        {
            var result = _homeworkContentDal.GetAll().SingleOrDefault(hc => hc.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<HomeworkContent>(_homeworkContentDal.Get(hc => hc.Id == id));
            }

            return new ErrorDataResult<HomeworkContent>(Messages.InvalidHomeworkContent);
        }

        public IResult Update(IFormFile file, HomeworkContent homeworkContent)
        {
            var result = _homeworkContentDal.GetAll().SingleOrDefault(hc => hc.Id == homeworkContent.Id);
            if (result != null)
            {
                if (homeworkContent.QuestionContent == null)
                {
                    var prevImagePath = result.ImagePath;
                    _fileHelper.Update(file,ImagePaths.HomeworkContentsPath + prevImagePath,ImagePaths.HomeworkContentsPath);
                }
                homeworkContent.Date = DateTime.Now;
                _homeworkContentDal.Update(homeworkContent);
                return new SuccesResult(Messages.UpdatedHomeworkContent);
            }

            return new ErrorResult(Messages.InvalidHomeworkContent);
        }

        public IResult Delete(HomeworkContent homeworkContent)
        {
            var result = _homeworkContentDal.GetAll().SingleOrDefault(hc => hc.Id == homeworkContent.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.HomeworkContentsPath + prevImagePath);
                _homeworkContentDal.Delete(homeworkContent);
                return new SuccesResult(Messages.DeletedHomeworkContent);
            }
            return new ErrorResult(Messages.InvalidHomeworkContent);
        }
    }
}
