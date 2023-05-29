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
    public class EfLecturerDal:EfRepositoryBase<Lecturer,ProjectDbContext>,ILecturerDal
    {
        //public List<LecturerDetailsDto> LecturerDetails()
        //{
        //    using (ProjectDbContext context = new ProjectDbContext())
        //    {
        //        var result = from lect in context.Lecturers
        //            join less in context.Lessons 
        //                on lect.Id equals less.LecturerId
        //            select new LecturerDetailsDto
        //            {
        //                 Le
        //                LessonCode = less.LessonCode, LessonName = less.LessonName
        //            };
        //        return result.ToList();
        //    }
        //}
    }
}
