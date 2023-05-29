using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfLessonDal : EfRepositoryBase<Lesson, ProjectDbContext>, ILessonDal
    {
        public List<LessonDetailDto> GetLessonsWithDetail()
        {
            using (ProjectDbContext context = new ProjectDbContext()) 
            {
                var list = from lesson in context.Lessons
                           join lect in context.Lecturers on
                           lesson.LecturerId equals lect.Id
                           join
                           p in context.Periods on
                           lesson.PeriodId equals p.Id
                           select new LessonDetailDto
                           {
                               LessonId= lesson.Id,
                               LecturerName = lect.FullName,
                               LessonCode = lesson.LessonCode,
                               LessonName = lesson.LessonName,
                               PeriodName = p.PeriodName
                           };
                return list.ToList();               
            }
        }

        public List<LessonDetailDto> GetLessonsWithDetailById(string userId)
        {
            using (ProjectDbContext context = new ProjectDbContext())
            {
                var list = from lesson in context.Lessons
                           join lect in context.Lecturers on
                           lesson.LecturerId equals lect.Id
                           join
                           p in context.Periods on
                           lesson.PeriodId equals p.Id
                           where lect.UserId == userId
                           select new LessonDetailDto
                           {
                               LessonId = lesson.Id,
                               LecturerName = lect.FullName,
                               LessonCode = lesson.LessonCode,
                               LessonName = lesson.LessonName,
                               PeriodName = p.PeriodName
                           };
                return list.ToList();
            }
        }
    }
}
