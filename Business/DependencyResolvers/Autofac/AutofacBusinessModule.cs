using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstact;
using Business.Abstact.LessonContent;
using Business.Abstarct;
using Business.Abstract;
using Business.Abstract.LessonContent;
using Business.Concrete;
using Business.Concrete.LeessonContent;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Abstract.LessonContent;
using DataAccess.Concrete;
using DataAccess.Concrete.LessonContent;
using DataAccess.Concrete.LesssonContent;
using Entities;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            builder.RegisterType<LecturerManager>().As<ILecturerService>().SingleInstance();
            builder.RegisterType<EfLecturerDal>().As<ILecturerDal>().SingleInstance();
            
            builder.RegisterType<PeriodManager>().As<IPeriodService>().SingleInstance();
            builder.RegisterType<EfPeriodDal>().As<IPeriodDal>().SingleInstance();

            builder.RegisterType<ProgramOutputManager>().As<IProgramOutputService>().SingleInstance();
            builder.RegisterType<EfProgramOutputDal>().As<IProgramOutputDal>().SingleInstance();

            builder.RegisterType<MidtermExamManager>().As<IMidtermExamService>().SingleInstance();
            builder.RegisterType<EfMidtermExamDal>().As<IMidtermExamDal>().SingleInstance();
            builder.RegisterType<MidtermExamQuestionManager>().As<IMidtermExamQuestionService>().SingleInstance();
            builder.RegisterType<EfMidtermExamQuestionDal>().As<IMidtermExamQuestionDal>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();  /**/

            builder.RegisterType<FinalExamManager>().As<IFinalExamService>().SingleInstance();
            builder.RegisterType<EfFinalExamDal>().As<IFinalExamDal>().SingleInstance();
            builder.RegisterType<FinalExamQuestionManager>().As<IFinalExamQuestionService>().SingleInstance();
            builder.RegisterType<EfFinalExamQuestionDal>().As<IFinalExamQuestionDal>().SingleInstance();

            builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>().SingleInstance();
            builder.RegisterType<ProjectContentManager>().As<IProjectContentService>().SingleInstance();
            builder.RegisterType<EfProjectContentDal>().As<IProjectContentDal>().SingleInstance();
           
            builder.RegisterType<HomeworkManager>().As<IHomeworkService>().SingleInstance();
            builder.RegisterType<EfHomeworkDal>().As<IHomeworkDal>().SingleInstance();
            builder.RegisterType<HomeworkContentManager>().As<IHomeworkContentService>().SingleInstance();
            builder.RegisterType<EfHomeworkContentDal>().As<IHomeworkContentDal>().SingleInstance();

            builder.RegisterType<ApplicationManager>().As<IApplicationService>().SingleInstance();
            builder.RegisterType<EfApplicationDal>().As<IApplicationDal>().SingleInstance();
            builder.RegisterType<ApplicationContentManager>().As<IApplicationContentService>().SingleInstance();
            builder.RegisterType<EfApplicationContentDal>().As<IApplicationContentDal>().SingleInstance();

            builder.RegisterType<LearningOutComeManager>().As<ILearningOutComeService>().SingleInstance();
            builder.RegisterType<EfLearningOutComeDal>().As<ILearningOutComeDal>().SingleInstance();
            builder.RegisterType<LearningOutComeContentManager>().As<ILearningOutComeContentService>().SingleInstance();
            builder.RegisterType<EfLearningOutComeContentDal>().As<ILearningOutComeContentDal>().SingleInstance();

            builder.RegisterType<LessonDocumentManager>().As<ILessonDocumentService>().SingleInstance();
            builder.RegisterType<EfLessonDocumentDal>().As<ILessonDocumentDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}