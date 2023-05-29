using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;

namespace Business.Concrete
{
    public class LessonManager:ILessonService
    {
        private ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Add(Lesson lesson)
        {
            var result = BusinessRules.Run(CheckLessonLimitByLecturerId(lesson.LecturerId));
            if (!result.IsSuccess)
            {
                return result;
            }
            _lessonDal.Add(lesson);
            return new SuccesResult(Messages.AddedLesson);
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(), Messages.ListedLessons);
        }

        public IDataResult<Lesson> GetById(int id)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(lesson => lesson.Id == id));
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Update(Lesson lesson)
        {
            var lesson1 = _lessonDal.Get(l => l.Id == lesson.Id);
            if (lesson1 != null)
            {
                _lessonDal.Update(lesson);
                return new SuccesResult(Messages.UpdatedLesson);
            }
            return new ErrorResult(Messages.InvalidLesson);
        }

        public IResult Delete(int lessonId)
        {
            var lesson1 = _lessonDal.Get(l => l.Id == lessonId);
            if (lesson1 != null)
            {
                _lessonDal.Delete(lesson1);
                return new SuccesResult(Messages.DeletedLesson);
            }
            return new ErrorResult(Messages.InvalidLesson);
        }

        private IResult CheckLessonLimitByLecturerId(int? lecturerId)
        {
            var result = _lessonDal.GetAll(l => l.LecturerId == lecturerId);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.LimitExceeded);
            }

            return new SuccesResult();
        }

        public IDataResult<List<LessonDetailDto>> GetAllLessonsWithDetail()
        {
            var result = _lessonDal.GetLessonsWithDetail();
            return new SuccessDataResult<List<LessonDetailDto>>(result);
        }

        public IDataResult<List<LessonDetailDto>> GetAllLessonsWithDetailById(string id)
        {
            var result = _lessonDal.GetLessonsWithDetailById(id);
            return new SuccessDataResult<List<LessonDetailDto>>(result);
        }
    }
}