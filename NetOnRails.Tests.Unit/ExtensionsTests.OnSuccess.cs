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

        [Fact]
        public void ShouldNotInvokeActionOnResultFailure()
        {
            //Given
            int value = 15;
            int expected = 15;

            Result<int, Exception> succededResult = CreateFailedResult<int, Exception>(new Exception());

            //When
            succededResult.OnSuccess(() => { value = value + 1; });

            //Then
            value.ShouldBe(expected);
        }
    }
}
