using Core.Utilities.Abstract;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Business.Abstract
{
    public interface IProgramOutputService
    {
        IResult Add(IFormFile file, ProgramOutput programOutput);
        IDataResult<List<ProgramOutput>> GetAll();
        IDataResult<ProgramOutput> GetById(int id);
        IResult Update(IFormFile file, ProgramOutput programOutput);
        IResult Delete(ProgramOutput programOutput);
    }
}
