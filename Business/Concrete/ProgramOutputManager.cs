using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProgramOutputManager:IProgramOutputService
    {
        private IProgramOutputDal _programOutputDal;
        IFileHelper _fileHelper;

        public ProgramOutputManager(IProgramOutputDal programOutputDal,IFileHelper fileHelper)
        {
            _programOutputDal = programOutputDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ProgramOutput programOutput)
        {
            programOutput.ImagePath = _fileHelper.Upload(file,ImagePaths.ProgramOutputsPath);
            programOutput.UploadDate = DateTime.Now;

            _programOutputDal.Add(programOutput);
            return new SuccesResult(Messages.AddedProgramOutput);
        }

        public IDataResult<List<ProgramOutput>> GetAll()
        {
            return new SuccessDataResult<List<ProgramOutput>>(_programOutputDal.GetAll(), Messages.ListedProgramOutputs);
        }

        public IDataResult<ProgramOutput> GetById(int id)
        {
            var result = _programOutputDal.GetAll().SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<ProgramOutput>(_programOutputDal.Get(p => p.Id == id));
            }

            return new ErrorDataResult<ProgramOutput>(Messages.InvalidProgramOutput);
        }

        public IResult Update(IFormFile file, ProgramOutput programOutput)
        {
            var result = _programOutputDal.GetAll().SingleOrDefault(p => p.Id == programOutput.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Update(file, ImagePaths.ProgramOutputsPath + prevImagePath,ImagePaths.ProgramOutputsPath);

                _programOutputDal.Update(programOutput);
                return new SuccesResult(Messages.UpdatedProgramOutput);
            }

            return new ErrorResult(Messages.InvalidProgramOutput);
        }

        public IResult Delete(ProgramOutput programOutput)
        {
            var result = _programOutputDal.GetAll().SingleOrDefault(p => p.Id == programOutput.Id);
            if (result != null)
            {
                var prevImagePath = result.ImagePath;
                _fileHelper.Delete(ImagePaths.ProgramOutputsPath + prevImagePath);

                _programOutputDal.Delete(programOutput);
                return new SuccesResult(Messages.DeletedProgramOutput);
            }

            return new ErrorResult(Messages.InvalidProgramOutput);
        }
    }
}
