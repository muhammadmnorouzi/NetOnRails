namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static Result<TData, TError> OnSuccess<TData, TError>(this Result<TData, TError> result, Action<TData> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }
    }
}
