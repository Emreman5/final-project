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
    public class EfProjectDal:EfRepositoryBase<Project,ProjectDbContext>,IProjectDal
    {
        public ProjectDetailsDto GetProjectDetails(int projectId)
        {
            IProjectContentDal projectContentDal = new EfProjectContentDal();
            var projectContents = projectContentDal.GetAll(pc => pc.ProjectId == projectId);
            
            var projectContentList = new List<ProjectContentDisplay>();
            projectContents.ForEach(pc => 
                projectContentList.Add( new ProjectContentDisplay()
                {
                    QuestionName = pc.QuestionName,
                    QuestionContent = pc.QuestionContent,
                    ImagePath = pc.ImagePath
                })
            );

            var project = Get(p => p.Id == projectId);
            if (project != null)
            {
                var projectDetails = new ProjectDetailsDto()
                {
                    ProjectName = project.ProjectName,
                    ProjectContents = projectContentList,
                    Description = project.Description
                };

                return projectDetails;
            }

            return null;
        }
    }
}
