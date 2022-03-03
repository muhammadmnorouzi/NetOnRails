using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public partial class ExtensionsTests
    {
        [Fact]
        public void ShouldInvokeActionOnResultSuccess()
        {
            //Given
            int givenValue = 15;
            int expected = 16;

            Result<int, Exception> succededResult = CreateSuccededResult<int, Exception>(givenValue);

            //When
            succededResult.OnSuccess(() => { givenValue = givenValue + 1; });

            //Then
            givenValue.ShouldBe(expected);
        }
    }
}
