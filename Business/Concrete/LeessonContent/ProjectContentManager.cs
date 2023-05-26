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
    public class ProjectContentManager:IProjectContentService
    {
        private IProjectContentDal _projectContentDal;
        IFileHelper _fileHelper;

        public ProjectContentManager(IProjectContentDal projectContentDal,IFileHelper fileHelper)
        {
            _projectContentDal = projectContentDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ProjectContent projectContent)
        {
            if (projectContent.QuestionContent == null)
            {
                projectContent.ImagePath = _fileHelper.Upload(file, ImagePaths.ProjectContentsPath);
            }

            projectContent.Date = DateTime.Now;
            _projectContentDal.Add(projectContent);
            return new SuccesResult(Messages.AddedProjectContent);
        }

        public IDataResult<List<ProjectContent>> GetAll()
        {
            return new SuccessDataResult<List<ProjectContent>>(_projectContentDal.GetAll(), Messages.ListedProjeectContent);
        }

        public IDataResult<ProjectContent> GetById(int id)
        {
            var result = _projectContentDal.GetAll().SingleOrDefault(pc => pc.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<ProjectContent>(_projectContentDal.Get(pc => pc.Id == id));
            }

            return new ErrorDataResult<ProjectContent>(Messages.InvalidProjectContent);
        }

        public IResult Update(IFormFile file, ProjectContent projectContent)
        {
            var result = _projectContentDal.GetAll().SingleOrDefault(pc => pc.Id == projectContent.Id);
            if (result != null)
            {
                if (projectContent.QuestionContent == null)
                {
                    var prevImagePath = result.ImagePath;
                    _fileHelper.Update(file, ImagePaths.ProjectContentsPath + prevImagePath, ImagePaths.ProjectContentsPath);
                }
                projectContent.Date = DateTime.Now;
                _projectContentDal.Update(projectContent);
                return new SuccesResult(Messages.UpdatedProjectContent);
            }

            return new ErrorResult(Messages.InvalidProjectContent);

        }

        public IResult Delete(ProjectContent projectContent)
        {
            var result = _projectContentDal.GetAll().SingleOrDefault(pc => pc.Id == projectContent.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.ProjectContentsPath + prevImagePath);
                
                _projectContentDal.Delete(projectContent);
                return new SuccesResult(Messages.DeletedProjectContent);
            }

            return new ErrorResult(Messages.InvalidProjectContent);
        }
    }
}
