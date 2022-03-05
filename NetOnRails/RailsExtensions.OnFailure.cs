namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static Result<TData, TError> OnFailure<TData, TError>(
            this Result<TData, TError> result,
            Action<TError> action!!)
        {
            if (!result.IsSuccess)
            {
                action(result.Error);
            }

            return result;
        }
    }
}