namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static Result<TDataOut, TError> Bind<TDataIn, TError, TDataOut>(
            this Result<TDataIn, TError> result,
            Func<TDataIn, Result<TDataOut, TError>> switchFunction!!)
        {
            return result.IsSuccess
                ? switchFunction(result.Value)
                : Result.Failure<TDataOut, TError>(result.Error);
        }
    }
}