using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstact.LessonContent;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete.LeessonContent
{
    public class FinalExamQuestionManager:IFinalExamQuestionService
    {
        private IFinalExamQuestionDal _finalExamQuestionDal;
        IFileHelper _fileHelper;

        public FinalExamQuestionManager(IFinalExamQuestionDal finalExamQuestionDal, IFileHelper fileHelper)
        {
            _finalExamQuestionDal = finalExamQuestionDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, FinalExamQuestion question)
        {
            if (question.QuestionContent == null)
            {
                question.ImagePath = _fileHelper.Upload(file, ImagePaths.FinalQuestionsPath);
            }
            question.Date = DateTime.Now;
            _finalExamQuestionDal.Add(question);
            return new SuccesResult(Messages.AddedFinalExamQuestion);
        }

        public IDataResult<List<FinalExamQuestion>> GetAll()
        {
            return new SuccessDataResult<List<FinalExamQuestion>>(_finalExamQuestionDal.GetAll(), Messages.ListedFinalExamQuestions);
        }

        public IDataResult<FinalExamQuestion> GetById(int id)
        {
            var result = _finalExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<FinalExamQuestion>(_finalExamQuestionDal.Get(q => q.Id == id));
            }

            return new ErrorDataResult<FinalExamQuestion>(Messages.InvalidFinalExamQuestion);
        }

        public IResult Update(IFormFile file, FinalExamQuestion question)
        {
            var result = _finalExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == question.Id);
            if (result != null)
            {
                if (question.QuestionContent == null)
                {
                    var previousImagePath = result.ImagePath;
                    question.ImagePath = _fileHelper.Update(file, ImagePaths.FinalQuestionsPath + previousImagePath, ImagePaths.FinalQuestionsPath);
                }
                question.Date = DateTime.Now;

                _finalExamQuestionDal.Update(question);
                return new SuccesResult(Messages.UpdatedFinalExamQuestion);
            }

            return new ErrorResult(Messages.InvalidFinalExamQuestion);
        }

        public IResult Delete(FinalExamQuestion question)
        {
            var result = _finalExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == question.Id);
            if (result != null)
            {
                var previousImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.FinalQuestionsPath + previousImagePath);
                _finalExamQuestionDal.Delete(question);
                return new SuccesResult(Messages.DeletedFinalExamQuestion);
            }

            return new ErrorResult(Messages.InvalidFinalExamQuestion);
        }
    }
}
