using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetOnRails.Tests.Unit
{
    public abstract class TestBase
    {

        public Result<TData, TError> CreateSuccededResult<TData, TError>(TData data)
        {
            return Result.Success<TData, TError>(data);
        }

        public Result<TData, TError> CreateFailedResult<TData, TError>(TError error)
        {
            return Result.Failure<TData, TError>(error);
        }
    }
}
