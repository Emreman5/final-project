using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.LessonContent;
using DataAccess.Concrete.LessonContent;
using Entities.DTOs;
using Entities.LessonContent;

namespace DataAccess.Concrete.LesssonContent
{
    public class EfMidtermExamDal : EfRepositoryBase<MidtermExam, ProjectDbContext>, IMidtermExamDal
    {
        public MidtermExamDetailsDto GetMidtermExamDetails(int midtermExamId)
        {
            IMidtermExamQuestionDal _midtermExamQuestionDal = new EfMidtermExamQuestionDal();
            var questions = _midtermExamQuestionDal.GetAll(q => q.MidtermExamId == midtermExamId);

            var questionList = new List<MidtermQuestion>();
            questions.ForEach(q => questionList.Add(
                new MidtermQuestion
                    {
                        QuestionName = q.QuestionName,
                        ImagePath = q.ImagePath,
                        QuestionContent = q.QuestionContent
                    })
            );

            var midExam = Get(ex => ex.Id == midtermExamId);
            if (midExam != null)
            {
                var midtermExamDetails = new MidtermExamDetailsDto()
                {
                    MidtermExamName = midExam.MidtermExamName,
                    MidtermExamQuestions = questionList,
                    Description = midExam.Description
                };

                return midtermExamDetails;
            }

            return null;

        }
    }
}
