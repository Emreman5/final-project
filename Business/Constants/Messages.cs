using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.LessonContent;

namespace Business.Constants
{
    public class Messages
    {
        public static string AddedLesson => "Ders eklendi";

        public static string ListedLessons
        {
            get { return "Dersler listelendi"; }
        }

        public static string UpdatedLesson => "Ders bilgileri güncellendi";
        public static string DeletedLesson => "Ders silindi";

        public static string InvalidLesson => "Bu Id'ye ait ders bulunamadı";
        public static string AddedLecturer => "Öğretim Üyesi eklendi";
        public static string ListedLecturers => "Öğretim Üyeleri listelendi";
        public static string UpdatedLecturer => "Öğretim Üyesi bilgileri güncellendi";
        public static string InvalidLecturer => "Bu Id'ye ait öğretim üyesi bulunamadı";
        public static string DeletedLecturer => "Öğretim Üyesi Silindi";
        public static string AddedPeriod => "Dönem eklendi";
        public static string UpdatedPeriod => "Dönem bilgileri güncellendi";
        public static string InvalidPeriod => "Bu Id'ye ait dönem bulunamadı";
        public static string DeletedPeriod => "Dönem bilgileri silindi";

        public static string AddedMidtermExam => "Vize sınavı eklendi";
        public static string ListedMidtermExam => "Vize sınavları listelendi";
        public static string UpdatedMidtermExam => "Vize sınavı bilgileri güncellendi";
        public static string InvalidMidtermExam => "Bu Id'ye ait vize sınavı bulunamadı";
        public static string DeletedMidtermExam => "Vize sınavı silindi";
        public static string AddedMidtermExamQuestion => "Vize sınavı sorusu eklendi";
        public static string ListedMidtermExamQuestions => "Vize sınavı soruları listelendi";
        public static string DeletedMidtermExamQuestion => "Vize sınavı sorusu silindi";
        public static string InvalidMidtermExamQuestion => "Bu Id'ye ait vize sınavı sorusu bulunamadı";
        public static string UpdatedMidtermExamQuestion => "Vize sınavı sorusu göncellendi";

        public static string AddedFinalExam => "Final sınavı eklendi";
        public static string ListedFinalExams => "Final sınavları listelendi";
        public static string UpdatedFinalExam => "Final sınavı bilgileri güncellendi";
        public static string InvalidFinalExam => "Bu Id'ye ait final sınavı bulunamadı";
        public static string DeletedFinalExam => "Final sınavı silindi";
        public static string AddedFinalExamQuestion => "Final sınavı sorusu eklendi";
        public static string ListedFinalExamQuestions => "Final sınavı soruları listelendi";
        public static string InvalidFinalExamQuestion => "Bu Id'ye ait final sınavı sorusu bulunamadı";
        public static string UpdatedFinalExamQuestion => "Final sınavı sorusu güncellendi";
        public static string DeletedFinalExamQuestion => "Final sınavı sorusu silindi";
        public static string AddedProject => "Proje eklendi";
        public static string ListedProjects => "Projeler listelendi";
        public static string InvalidProject => "Bu Id'ye ait proje bulunamadı";
        public static string UpdatedProject => "Proje bilgileri güncellendi";
        public static string DeletedProject => "Proje bilgileri silindi";
        public static string AddedProjectContent => "Proje içeriği eklendi";
        public static string ListedProjeectContent => "Proje içerikleri listelendi";
        public static string InvalidProjectContent => "Bu Id'ye ait proje içeriği bulunamadı";
        public static string UpdatedProjectContent => "Proje içeriği güncellendi";
        public static string DeletedProjectContent => "Proje içeriği silindi";

        public static string AddedHomework => "Ödev eklendi";
        public static string ListedHomeworks => "Ödevler listelendi";
        public static string InvalidHomework => "Bu Id'ye ait ödev bulunamadı";
        public static string UpdatedHomework => "Ödev bilgileri güncellendi";
        public static string DeletedHomework => "Ödev silindi";
        public static string AddedHomeworkContent => "Ödev içeriği eklendi";
        public static string ListedHomeworkContent => "Ödev içerikleri listelendi";
        public static string InvalidHomeworkContent => "Bu Id'ye ait ödev içeriği bulunamadı ";
        public static string UpdatedHomeworkContent => "Ödev içeriği güncellendi";
        public static string DeletedHomeworkContent => "Ödev içeriği silindi";

        public static string AddedApplication => "Uygulama eklendi";
        public static string ListedApplications => "Uygulamalar listelendi";
        public static string InvalidApplication => "Bu Id'ye ait uygulama bulunamadı";
        public static string UpdatedApplication => "Uygulama bilgileri güncellendi";
        public static string DeletedApplication => "Uygulama silindi";
        public static string AddedApplicationContent => "Uygulama içeriği eklendi";
        public static string ListedApplicationContents => "Uygulama içerikleri listelendi";
        public static string InvalidApplicationContent => "Bu Id'ye ait uygulama içeriği bulunamadı";
        public static string UpdatedApplicationContent => "Uygulama içeriği güncellendi";
        public static string DeletedApplicationContent => "Uygulama içeriği silindi";

        public static string AddedLearningOutCome => "Öğrenme çıktısı eklendi";
        public static string ListedLearningOutComes => "Öğrenme çıktıları listelendi";
        public static string InvalidLearningOutCome => "Bu Id'ye ait öğrenme çıktısı bulunamadı";
        public static string UpdatedLearningOutCome => "Öğrenme çıktısı bilgileri güncellendi";
        public static string DeletedLearningOutCome => "Öğrenme çıktısı silindi";
        public static string AddedLearningOutComeContent => "Öğrenme çıktısı maddesi eklendi";
        public static string ListedLearningOutComeContents => "Öğrenme çıktısı maddeleri listelendi";
        public static string InvalidLearningOutComeContent => "Bu Id'ye ait öğrenme çıktısı maddesi bulunamadı";
        public static string UpdatedLearningOutComeContent => "Öğrenme çıktısı maddesi güncellendi";
        public static string DeletedLearningOutComeContent => "Öğrenme çıktısı maddesi silindi";

        public static string AddedProgramOutput => "Program çıktısı eklendi";
        public static string ListedProgramOutputs => "Program çıktıları listelendi";
        public static string InvalidProgramOutput => "Bu Id'ye ait program çıktısı bulunamadı";
        public static string UpdatedProgramOutput => "Program çıktısı güncellendi";
        public static string DeletedProgramOutput => "Program çıktısı silindi";

        public static string AddedLessonDocument => "Ders dökümanı eklendi";
        public static string ListedLessonDocument => "Ders dökümanları listelendi";
        public static string InvalidLessonDocument => "Bu Id'ye ait ders dökümanı bulunamadı";
        public static string UpdatedLessonDocument => "Ders dökümanı güncellendi";
        public static string DeletedLessonDocument => "Ders dökümanı silindi";

        public static string LimitExceeded => "Ders limiti aşıldığından yeni ders eklenemiyor";
    }
}