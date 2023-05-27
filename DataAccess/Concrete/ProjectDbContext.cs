using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.LessonContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace DataAccess.Concrete
{
    public class ProjectDbContext : IdentityDbContext<CustomUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=uni_db;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<ApplicationUserToken> AspNetUserTokens { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<ProgramOutput> ProgramOutputs { get; set; }

        public DbSet<MidtermExam> MidtermExams { get; set; }
        public DbSet<MidtermExamQuestion> MidtermExamQuestions { get; set; }

        public DbSet<FinalExam> FinalExams { get; set; }
        public DbSet<FinalExamQuestion> FinalExamQuestions { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectContent> ProjectContents { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkContent> HomeworkContents { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationContent> ApplicationContents { get; set; }

        public DbSet<LearningOutCome> LearningOutComes { get; set;}
        public DbSet<LearningOutComeContent> LearningOutComeContents { get; set; }

        public DbSet<LessonDocument> LessonDocuments { get; set; }
    }
}
