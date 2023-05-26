using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EfProgramOutputDal:EfRepositoryBase<ProgramOutput,ProjectDbContext>,IProgramOutputDal
    {
    }
}
