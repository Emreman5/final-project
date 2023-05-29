using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstarct;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;

namespace Business.Concrete
{
    public class LecturerManager:ILecturerService
    {
        private ILecturerDal _lecturerDal;

        public LecturerManager(ILecturerDal lecturerDal)
        {
            _lecturerDal = lecturerDal;
        }
        public IResult Add(Lecturer lecturer)
        {
            _lecturerDal.Add(lecturer);
            return new SuccesResult(Messages.AddedLecturer);
        }

        public IDataResult<List<Lecturer>> GetAll()
        {
            return new SuccessDataResult<List<Lecturer>>(_lecturerDal.GetAll(), Messages.ListedLecturers);
        }

        public IDataResult<Lecturer> GetById(int id)
        {
            return new SuccessDataResult<Lecturer>(_lecturerDal.Get(l => l.Id == id));
        }

        public IResult Update(Lecturer lecturer)
        {
            var result = GetById(lecturer.Id);
            if (result != null)
            {
                _lecturerDal.Update(lecturer);
                return new SuccesResult(Messages.UpdatedLecturer);
            }

            return new ErrorResult(Messages.InvalidLecturer);
        }

        public IResult Delete(Lecturer lecturer)
        {
            var result = GetById(lecturer.Id);
            if (result != null)
            {
                _lecturerDal.Delete(lecturer);
                return new SuccesResult(Messages.DeletedLecturer);
            }

            return new ErrorResult(Messages.InvalidLecturer);
        }

    }
}