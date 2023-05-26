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
    public class EfLearningOutComeDal:EfRepositoryBase<LearningOutCome,ProjectDbContext>,ILearningOutComeDal
    {
        public LearningOutComeDetailsDto GetLearningOutComeDetails(int learningOutComeId)
        {
            ILearningOutComeContentDal learningOutComeContentDal = new EfLearningOutComeContentDal();
            var learningOutComeContents =
                learningOutComeContentDal.GetAll(lc => lc.LearningOutComeId == learningOutComeId);

            var learningOutComeContentList = new List<LearningOutComeContentDisplay>();

            learningOutComeContents.ForEach( lc => learningOutComeContentList.Add(
                new LearningOutComeContentDisplay()
                {
                    SubstanceName = lc.SubstanceName,
                    SubstanceContent = lc.SubstanceContent
                }));

            var learningOutCome = Get(learnOutCome => learnOutCome.Id == learningOutComeId);
            if (learningOutCome != null)
            {
                var learningOutComeDetails = new LearningOutComeDetailsDto()
                {
                    LearningOutComeName = learningOutCome.LearningOutComeName,
                    LearningOutComeContents = learningOutComeContentList,
                    Description = learningOutCome.Description
                };

                return learningOutComeDetails;
            }

            return null;
        }
    }
}
