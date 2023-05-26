using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.LessonContent;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete.LeessonContent
{
    public class LessonDocumentManager:ILessonDocumentService
    {
        private ILessonDocumentDal _lessonDocumentDal;
        IFileHelper _fileHelper;

        public LessonDocumentManager(ILessonDocumentDal lessonDocumentDal,IFileHelper fileHelper)
        {
            _lessonDocumentDal = lessonDocumentDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, LessonDocument lessonDocument)
        {
            lessonDocument.ImagePath = _fileHelper.Upload(file, ImagePaths.LessonDocumentsPath);
            lessonDocument.UploadDate = DateTime.Now;
            
            _lessonDocumentDal.Add(lessonDocument);
            return new SuccesResult(Messages.AddedLessonDocument);
        }

        public IDataResult<List<LessonDocument>> GetAll()
        {
            return new SuccessDataResult<List<LessonDocument>>(_lessonDocumentDal.GetAll(), Messages.ListedLessonDocument);
        }

        public IDataResult<LessonDocument> GetById(int id)
        {
            var result = _lessonDocumentDal.GetAll().SingleOrDefault(ld => ld.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<LessonDocument>(_lessonDocumentDal.Get(ld => ld.Id == id));
            }

            return new ErrorDataResult<LessonDocument>(Messages.InvalidLessonDocument);
        }

        public IResult Update(IFormFile file, LessonDocument lessonDocument)
        {
            var result = _lessonDocumentDal.GetAll().SingleOrDefault(ld => ld.Id == lessonDocument.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Update(file,ImagePaths.LessonDocumentsPath + prevImagePath,ImagePaths.LessonDocumentsPath);
                lessonDocument.UploadDate = DateTime.Now;

                _lessonDocumentDal.Update(lessonDocument);
                return new SuccesResult(Messages.UpdatedLessonDocument);
            }

            return new ErrorResult(Messages.InvalidLessonDocument);
        }

        public IResult Delete(LessonDocument lessonDocument)
        {

            var result = _lessonDocumentDal.GetAll().SingleOrDefault(ld => ld.Id == lessonDocument.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.LessonDocumentsPath + prevImagePath);

                _lessonDocumentDal.Delete(lessonDocument);
                return new SuccesResult(Messages.DeletedLessonDocument);
            }

            return new ErrorResult(Messages.InvalidLessonDocument);
        }
    }
}
