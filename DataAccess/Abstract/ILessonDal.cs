using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ILessonDal:IEntityRepository<Lesson>
    {
        public List<LessonDetailDto> GetLessonsWithDetail();
        public List<LessonDetailDto> GetLessonsWithDetailById(string userId);
    }
}
