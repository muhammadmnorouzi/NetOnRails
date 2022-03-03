namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static void OnFailure<TData, TError>(this Result<TData, TError> result, Action action)
        {
            if (!result.IsSuccess)
            {
                action();
            }
        }

        public static void OnFailure<TData, TError>(this Result<TData, TError> result, Action<TError> action)
        {
            if (!result.IsSuccess)
            {
                action(result.Error);
            }
        }
    }
}