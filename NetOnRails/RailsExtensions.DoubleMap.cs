namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static Result<TDataOut, TError> DoubleMap<TDataIn, TError, TDataOut>(
            this Result<TDataIn, TError> result,
            Func<TDataIn, TDataOut> onSuccess!!,
            Action<TDataIn> onFailure!!)
        {
            if (result.IsSuccess)
            {
                return Result.Success<TDataOut, TError>(onSuccess(result.Value));
            }
            else
            {
                onFailure(result.Value);
                return Result.Failure<TDataOut, TError>(result.Error);
            }
        }
    }
}