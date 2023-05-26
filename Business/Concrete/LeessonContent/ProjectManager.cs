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
using Entities.LessonContent;

namespace Business.Concrete.LeessonContent
{
    public class ProjectManager:IProjectService
    {
        private IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        public IResult Add(Project project)
        {
            _projectDal.Add(project);
            return new SuccesResult(Messages.AddedProject);
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll(), Messages.ListedProjects);
        }

        public IDataResult<Project> GetById(int id)
        {
            var result = _projectDal.GetAll().SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Project>(_projectDal.Get(p => p.Id == id));
            }

            return new ErrorDataResult<Project>(Messages.InvalidProject);
        }

        public IResult Update(Project project)
        {
            var result = _projectDal.GetAll().SingleOrDefault(p => p.Id == project.Id);
            if (result != null)
            {
                _projectDal.Update(project);
                return new SuccesResult(Messages.UpdatedProject);
            }

            return new ErrorResult(Messages.InvalidProject);
        }

        public IResult Delete(Project project)
        {
            var result = _projectDal.GetAll().SingleOrDefault(p => p.Id == project.Id);
            if(result != null)
            {
                _projectDal.Delete(project);
                return new SuccesResult(Messages.DeletedProject);
            }
            return new ErrorResult(Messages.InvalidProject);
        }
    }
}
