using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tables2._0.Domain.Base.Common
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public Error Error { get; set; }

        public BaseResponse(T data)
        {
            Data = data;
            Error = Error.None;
        }

        public BaseResponse(Error error)
        {
            Data = default;
            Error = error;
        }
    }
}
