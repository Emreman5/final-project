using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ILecturerDal:IEntityRepository<Lecturer>
    {
        List<LecturerDetailsDto> LecturerDetails();
    }
}
