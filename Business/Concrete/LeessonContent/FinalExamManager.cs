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
    public class FinalExamManager:IFinalExamService
    {
        private IFinalExamDal _finalExamDal;

        public FinalExamManager(IFinalExamDal finalExamDal)
        {
            _finalExamDal = finalExamDal;
        }
        public IResult Add(FinalExam finalExam)
        {
            _finalExamDal.Add(finalExam);
            return new SuccesResult(Messages.AddedFinalExam);
        }

        public IDataResult<List<FinalExam>> GetAll()
        {
            return new SuccessDataResult<List<FinalExam>>(_finalExamDal.GetAll(), Messages.ListedFinalExams);
        }

        public IDataResult<FinalExam> GetById(int id)
        {
            var result = _finalExamDal.GetAll().SingleOrDefault(ex => ex.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<FinalExam>(_finalExamDal.Get(ex => ex.Id == id));
            }

            return new ErrorDataResult<FinalExam>(Messages.InvalidFinalExam);
        }

        public IResult Update(FinalExam finalExam)
        {
            var result = _finalExamDal.GetAll().SingleOrDefault(ex => ex.Id == finalExam.Id);
            if (result != null)
            {
                _finalExamDal.Update(finalExam);
                return new SuccesResult(Messages.UpdatedFinalExam);
            }

            return new ErrorResult(Messages.InvalidFinalExam);
        }

        public IResult Delete(FinalExam finalExam)
        {

            var result = _finalExamDal.GetAll().SingleOrDefault(ex => ex.Id == finalExam.Id);
            if (result != null)
            {
                _finalExamDal.Delete(finalExam);
                return new SuccesResult(Messages.DeletedFinalExam);
            }

            return new ErrorResult(Messages.InvalidFinalExam);
        }

        public IDataResult<FinalExamDetailsDto> GetFinalExamDetails(int finalExamId)
        {
            var result = _finalExamDal.GetFinalExamDetails(finalExamId);
            if (result != null)
            {
                return new SuccessDataResult<FinalExamDetailsDto>(_finalExamDal.GetFinalExamDetails(finalExamId));
            }

            return new ErrorDataResult<FinalExamDetailsDto>(Messages.InvalidFinalExam);
        }
    }
}