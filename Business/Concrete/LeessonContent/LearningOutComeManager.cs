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
    public class LearningOutComeManager:ILearningOutComeService
    {
        private ILearningOutComeDal _learningOutComeDal;
        public LearningOutComeManager(ILearningOutComeDal learningOutComeDal)
        {
            _learningOutComeDal = learningOutComeDal;
        }

        public IResult Add(LearningOutCome learningOutCome)
        {
            _learningOutComeDal.Add(learningOutCome);
            return new SuccesResult(Messages.AddedLearningOutCome);
        }

        public IDataResult<List<LearningOutCome>> GetAll()
        {
            return new SuccessDataResult<List<LearningOutCome>>(_learningOutComeDal.GetAll(), Messages.ListedLearningOutComes);
        }

        public IDataResult<LearningOutCome> GetById(int id)
        {
            var result = _learningOutComeDal.GetAll().SingleOrDefault(l => l.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<LearningOutCome>(_learningOutComeDal.Get(l => l.Id == id));
            }

            return new ErrorDataResult<LearningOutCome>(Messages.InvalidLearningOutCome);
        }

        public IResult Update(LearningOutCome learningOutCome)
        {
            var result = _learningOutComeDal.GetAll().SingleOrDefault(l => l.Id == learningOutCome.Id);
            if (result != null)
            {
                _learningOutComeDal.Update(learningOutCome);
                return new SuccesResult(Messages.UpdatedLearningOutCome);
            }

            return new ErrorResult(Messages.InvalidLearningOutCome);
        }

        public IResult Delete(LearningOutCome learningOutCome)
        {

            var result = _learningOutComeDal.GetAll().SingleOrDefault(l => l.Id == learningOutCome.Id);
            if (result != null)
            {
                _learningOutComeDal.Delete(learningOutCome);
                return new SuccesResult(Messages.DeletedLearningOutCome);
            }

            return new ErrorResult(Messages.InvalidLearningOutCome);
        }

        public IDataResult<LearningOutComeDetailsDto> GetLearningOutComeDetails(int learningOutComeId)
        {
            var result = _learningOutComeDal.GetLearningOutComeDetails(learningOutComeId);
            if (result != null)
            {
                return new SuccessDataResult<LearningOutComeDetailsDto>(
                    _learningOutComeDal.GetLearningOutComeDetails(learningOutComeId));
            }

            return new ErrorDataResult<LearningOutComeDetailsDto>(Messages.InvalidLearningOutCome);
        }
    }
}
