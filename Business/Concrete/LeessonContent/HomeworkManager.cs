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
    public class HomeworkManager:IHomeworkService
    {
        private IHomeworkDal _homeworkDal;

        public HomeworkManager(IHomeworkDal homeworkDal)
        {
            _homeworkDal = homeworkDal;
        }

        public IResult Add(Homework homework)
        {
            _homeworkDal.Add(homework);
            return new SuccesResult(Messages.AddedHomework);
        }

        public IDataResult<List<Homework>> GetAll()
        {
            return new SuccessDataResult<List<Homework>>(_homeworkDal.GetAll(), Messages.ListedHomeworks);
        }

        public IDataResult<Homework> GetById(int id)
        {
            var result = _homeworkDal.GetAll().SingleOrDefault(h => h.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Homework>(_homeworkDal.Get(h => h.Id == id)); 
            }

            return new ErrorDataResult<Homework>(Messages.InvalidHomework);
        }

        public IResult Update(Homework homework)
        {
            var result = _homeworkDal.GetAll().SingleOrDefault(h => h.Id == homework.Id);
            if (result != null)
            {
                _homeworkDal.Update(result);
                return new SuccesResult(Messages.UpdatedHomework);
            }

            return new ErrorResult(Messages.InvalidHomework);
        }

        public IResult Delete(Homework homework)
        {

            var result = _homeworkDal.GetAll().SingleOrDefault(h => h.Id == homework.Id);
            if (result != null)
            {
                _homeworkDal.Delete(result);
                return new SuccesResult(Messages.DeletedHomework);
            }

            return new ErrorResult(Messages.InvalidHomework);
        }

        public IDataResult<HomeworkDetailsDto> GetHomeworkDetails(int homeworkId)
        {
            var result = _homeworkDal.GetHomeworkDetails(homeworkId);
            if (result != null)
            {
                return new SuccessDataResult<HomeworkDetailsDto>(_homeworkDal.GetHomeworkDetails(homeworkId));
            }

            return new ErrorDataResult<HomeworkDetailsDto>(Messages.InvalidHomework);
        }
    }
}
