using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetOnRails
{
    public static partial class RailsExtensions
    {
        public static void OnSuccess<TData, TError>(this Result<TData, TError> result, Action action)
        {
            if (result.IsSuccess)
            {
                action();
            }
        }

        public static void OnSuccess<TData, TError>(this Result<TData, TError> result, Action<TData> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }
        }
    }
}
