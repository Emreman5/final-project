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
    public class EfApplicationDal:EfRepositoryBase<Application,ProjectDbContext>,IApplicationDal
    {
        public ApplicationDetailsDto GetApplicationDetails(int applicationId)
        {
            IApplicationContentDal appContentDal = new EfApplicationContentDal();
            var appContents = appContentDal.GetAll(appcont => appcont.ApplicationId == applicationId);

            var appContentList = new List<ApplicationContentDisplay>();
            appContents.ForEach(ac => appContentList.Add(
                new ApplicationContentDisplay()
                {
                    QuestionName = ac.QuestionName,
                    ImagePath = ac.ImagePath,
                    QuestionContent = ac.QuestionContent
                })
            );

            var application = Get(app => app.Id == applicationId);
            if (application != null)
            {
                var appDetails = new ApplicationDetailsDto()
                {
                    ApplicationName = application.ApplicationName,
                    ApplicationContents = appContentList,
                    Description = application.Description
                };
                return appDetails;
            }

            return null;
        }
    }
}
