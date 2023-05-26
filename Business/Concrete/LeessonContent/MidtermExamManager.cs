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
    public class MidtermExamManager:IMidtermExamService
    {
        private IMidtermExamDal _midtermExamDal;

        public MidtermExamManager(IMidtermExamDal midtermExamDal)
        {
            _midtermExamDal = midtermExamDal;
        }
        public IResult Add(MidtermExam midtermExam)
        {
            midtermExam.MidtermExamTime = DateTime.Now;
            _midtermExamDal.Add(midtermExam);
            return new SuccesResult(Messages.AddedMidtermExam);
        }

        public IDataResult<List<MidtermExam>> GetAll()
        {
            return new SuccessDataResult<List<MidtermExam>>(_midtermExamDal.GetAll(), Messages.ListedMidtermExam);
        }

        public IDataResult<MidtermExam> GetById(int id)
        {
            return new SuccessDataResult<MidtermExam>(_midtermExamDal.Get(mex => mex.Id == id));
        }

        public IResult Update(MidtermExam midtermExam)
        {
            var result = _midtermExamDal.GetAll().SingleOrDefault(ex => ex.Id == midtermExam.Id);
            if (result != null)
            {
                _midtermExamDal.Update(midtermExam);
                return new SuccesResult(Messages.UpdatedMidtermExam);
            }

            return new ErrorResult(Messages.InvalidMidtermExam);
        }

        public IResult Delete(MidtermExam midtermExam)
        {
            var result = _midtermExamDal.GetAll().SingleOrDefault(ex => ex.Id == midtermExam.Id);
            if (result != null)
            {
                _midtermExamDal.Delete(midtermExam);
                return new SuccesResult(Messages.DeletedMidtermExam);
            }

            return new ErrorResult(Messages.InvalidMidtermExam);
        }

        public IDataResult<MidtermExamDetailsDto> GetMidtermExamDetails(int midtermExId)
        {
            var result = _midtermExamDal.GetMidtermExamDetails(midtermExId);
            if (result != null)
            {
                return new SuccessDataResult<MidtermExamDetailsDto>(_midtermExamDal.GetMidtermExamDetails(midtermExId));
            }

            return new ErrorDataResult<MidtermExamDetailsDto>(Messages.InvalidMidtermExam);
        }
    }
}