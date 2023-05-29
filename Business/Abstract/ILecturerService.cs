using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ILecturerService
    {
        IResult Add(Lecturer lecturer);
        IDataResult<List<Lecturer>> GetAll();
        IDataResult<Lecturer> GetById(int id);
        IResult Update(Lecturer lecturer);
        IResult Delete(Lecturer lecturer);
    }
}