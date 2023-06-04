using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;
using Entities;

namespace Business.Abstarct
{
    public interface IPeriodService
    {
        IResult Add(Period  period);
        IDataResult<List<Period>> GetAll();
        IDataResult<Period> GetById(int id);
        IResult Update(Period period);
        IResult Delete(int id);
    }
}