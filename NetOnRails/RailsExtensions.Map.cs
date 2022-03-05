namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static Result<TDataOut, TError> Map<TDataIn, TError, TDataOut>(
            this Result<TDataIn, TError> result,
            Func<TDataIn, TDataOut> singleTrackFunction!!)
        {
            return result.IsSuccess
                ? Result.Success<TDataOut, TError>(singleTrackFunction(result.Value))
                : Result.Failure<TDataOut, TError>(result.Error);
        }
    }
}