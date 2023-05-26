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
    public class EfHomeworkDal:EfRepositoryBase<Homework,ProjectDbContext>,IHomeworkDal
    {
        public HomeworkDetailsDto GetHomeworkDetails(int homeworkId)
        {
            IHomeworkContentDal homeworkContentDal = new EfHomeworkContentDal();
            var homeworkContents = homeworkContentDal.GetAll(hc => hc.HomeworkId == homeworkId);

            var homeworkContentList = new List<HomeworkContentDisplay>();
            homeworkContents.ForEach(hc => homeworkContentList.Add(new HomeworkContentDisplay()
            {
                QuestionName = hc.QuestionName,
                ImagePath = hc.ImagePath,
                QuestionContent = hc.QuestionContent
            }));

            var homework = Get(h => h.Id == homeworkId);
            if (homework!= null)
            {
                var homeworkDetails = new HomeworkDetailsDto()
                {
                    HomeworkName = homework.HomeworkName,
                    HomeworkContents = homeworkContentList,
                    Description = homework.Description
                };
                return homeworkDetails;
            }

            return null;
        }
    }
}
