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
    public class MidtermExamQuestionManager:IMidtermExamQuestionService
    {
        private IMidtermExamQuestionDal _midtermExamQuestionDal;
        IFileHelper _fileHelper;

        public MidtermExamQuestionManager(IMidtermExamQuestionDal midtermExamQuestionDal,IFileHelper fileHelper)
        {
            _midtermExamQuestionDal = midtermExamQuestionDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, MidtermExamQuestion question)
        {
            if (question.QuestionContent == null)
            {
                question.ImagePath = _fileHelper.Upload(file, ImagePaths.MidtermQuestionsPath);
            }

            question.Date = DateTime.Now;
           
            _midtermExamQuestionDal.Add(question);
            return new SuccesResult(Messages.AddedMidtermExamQuestion);
        }

        public IDataResult<List<MidtermExamQuestion>> GetAll()
        {
            return new SuccessDataResult<List<MidtermExamQuestion>>(_midtermExamQuestionDal.GetAll(),Messages.ListedMidtermExamQuestions);
        }

        public IDataResult<MidtermExamQuestion> GetById(int id)
        {
            var result = _midtermExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<MidtermExamQuestion>(_midtermExamQuestionDal.Get(q => q.Id == id));
            }

            return new ErrorDataResult<MidtermExamQuestion>(Messages.InvalidMidtermExamQuestion);

        }

        public IResult Update(IFormFile file, MidtermExamQuestion question)
        {
            var result = _midtermExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == question.Id);

            if (result != null)
            {
                if (question.QuestionContent == null)
                {
                    var previousImagePath = result.ImagePath;
                    question.ImagePath = _fileHelper.Update(file, ImagePaths.MidtermQuestionsPath + previousImagePath, ImagePaths.MidtermQuestionsPath);
                }
                question.Date = DateTime.Now;

                _midtermExamQuestionDal.Update(question);
                return new SuccesResult(Messages.UpdatedMidtermExamQuestion);
            }

            return new ErrorResult(Messages.InvalidMidtermExamQuestion);
        }

        public IResult Delete(MidtermExamQuestion question)
        {
            var result = _midtermExamQuestionDal.GetAll().SingleOrDefault(q => q.Id == question.Id);
            if (result != null)
            {
                var previousImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.MidtermQuestionsPath + previousImagePath);
                _midtermExamQuestionDal.Delete(question);
                return new SuccesResult(Messages.DeletedMidtermExamQuestion);
            }

            return new ErrorResult(Messages.InvalidMidtermExamQuestion);
        }
    }
}