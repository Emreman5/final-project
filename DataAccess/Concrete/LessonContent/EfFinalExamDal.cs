using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.LessonContent;
using Entities.DTOs;
using Entities.LessonContent;

namespace DataAccess.Concrete.LessonContent
{
    public class EfFinalExamDal:EfRepositoryBase<FinalExam,ProjectDbContext>,IFinalExamDal
    {
        public FinalExamDetailsDto GetFinalExamDetails(int finalExamId)
        {
            IFinalExamQuestionDal _finalExamQuesdal = new EfFinalExamQuestionDal();
            var questions = _finalExamQuesdal.GetAll(q => q.FinalExamId == finalExamId);

            var questionList = new List<FinalQuestion>();
            questions.ForEach(q => questionList.Add(
                new FinalQuestion
                {
                    QuestionName = q.QuestionName,
                    ImagePath = q.ImagePath,
                    QuestionContent = q.QuestionContent
                })
            );

            var finalExam = Get(ex => ex.Id == finalExamId);
            if (finalExam != null)
            {
                var finalExamDetails = new FinalExamDetailsDto()
                {
                    FinalExamName = finalExam.FinalExamName,
                    FinalExamQuestions = questionList,
                    Description = finalExam.Description
                };

                return finalExamDetails;
            }

            return null;
        }
    }
}
