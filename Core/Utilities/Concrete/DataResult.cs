using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete
{
    public class DataResult<T>:IDataResult<T>
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public T Data { get; }

        public DataResult(T data,bool isSuccess)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public DataResult(T data, bool isSuccess, string message) : this(data, isSuccess)
        {
            Message = message;
        }
    }
}
