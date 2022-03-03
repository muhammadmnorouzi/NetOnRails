using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetOnRails
{
    public struct Result
    {
        public static Result<TData, TError> Success<TData, TError>(T value)
        {
            return new Result<TData, TError>(value, true, default(TError));
        }

        public static Result<TData, TError> Failure<TData, TError>(Exception error)
        {
            return new Result<TData, TError>(default(TData), false, error);
        }
    }

    public readonly struct Result<TData, TError>
    {
        readonly TData _value;
        readonly bool _isSuccess;
        readonly TError _error;

        public Result(TData value, bool isSuccess, TError error)
        {
            _value = value;
            _isSuccess = isSuccess;
            _error = error;
        }

        public bool IsSuccess => _isSuccess;
        public bool IsFailure => !IsSuccess;
        public TData Value => _value;
        public TError Error => _error;
    }
}
