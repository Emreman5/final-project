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
    public class LearningOutComeContentManager:ILearningOutComeContentService
    {
        private ILearningOutComeContentDal _learningOutComeContentDal;
        
        public LearningOutComeContentManager(ILearningOutComeContentDal learningOutComeContentDal)
        {
            _learningOutComeContentDal = learningOutComeContentDal;
        }

        public IResult Add(LearningOutComeContent learningOutComeContent)
        {
            _learningOutComeContentDal.Add(learningOutComeContent);
            return new SuccesResult(Messages.AddedLearningOutComeContent);
        }

        public IDataResult<List<LearningOutComeContent>> GetAll()
        {
            return new SuccessDataResult<List<LearningOutComeContent>>(_learningOutComeContentDal.GetAll(), Messages.ListedLearningOutComeContents);
        }

        public IDataResult<LearningOutComeContent> GetById(int id)
        {
            var result = _learningOutComeContentDal.GetAll().SingleOrDefault(lc => lc.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<LearningOutComeContent>(_learningOutComeContentDal.Get(lc => lc.Id == id));
            }

            return new ErrorDataResult<LearningOutComeContent>(Messages.InvalidLearningOutComeContent);
        }

        public IResult Update(LearningOutComeContent learningOutComeContent)
        {
            var result = _learningOutComeContentDal.GetAll().SingleOrDefault(lc => lc.Id == learningOutComeContent.Id);
            if (result != null)
            {
                _learningOutComeContentDal.Update(learningOutComeContent);
                return new SuccesResult(Messages.UpdatedLearningOutComeContent);
            }

            return new ErrorResult(Messages.InvalidLearningOutComeContent);
        }

        public IResult Delete(LearningOutComeContent learningOutComeContent)
        {

            var result = _learningOutComeContentDal.GetAll().SingleOrDefault(lc => lc.Id == learningOutComeContent.Id);
            if (result != null)
            {
                _learningOutComeContentDal.Delete(learningOutComeContent);
                return new SuccesResult(Messages.DeletedLearningOutComeContent);
            }

            return new ErrorResult(Messages.InvalidLearningOutComeContent);
        }
    }
}
