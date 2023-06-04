using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class PeriodManager:IPeriodService
    {
        private IPeriodDal _periodDal;

        public PeriodManager(IPeriodDal periodDal)
        {
            _periodDal = periodDal;
        }
        public IResult Add(Period period)
        {
            _periodDal.Add(period);
            return new SuccesResult(Messages.AddedPeriod);
        }

        public IDataResult<List<Period>> GetAll()
        {
            return new SuccessDataResult<List<Period>>(_periodDal.GetAll());
        }

        public IDataResult<Period> GetById(int id)
        {
            return new SuccessDataResult<Period>(_periodDal.Get(p => p.Id == id));
        }

        public IResult Update(Period period)
        {
            var result = GetById(period.Id);
            if (result != null)
            {
                _periodDal.Update(period);
                return new SuccesResult(Messages.UpdatedPeriod);
            }

            return new ErrorResult(Messages.InvalidPeriod);
        }

        public IResult Delete(int id)
        {
            var result = _periodDal.Get(p => p.Id == id);
            if (result != null)
            {
                _periodDal.Delete(result);
                return new SuccesResult(Messages.DeletedPeriod);
            }
            return new ErrorResult(Messages.InvalidPeriod);
        }
    }
}