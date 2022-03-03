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
        public void OnSuccess_ShouldInvokeActionOnResultSuccess()
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
        public void OnSuccess_ShouldNotInvokeActionOnResultFailure()
        {
            //Given
            int value = 15;
            int expected = 15;

            Result<int, Exception> failedResult = CreateFailedResult<int, Exception>(new Exception());

            //When
            failedResult.OnSuccess(() => { value = value + 1; });

            //Then
            value.ShouldBe(expected);
        }

        [Fact]
        public void OnSuccess_ShouldInvokeActionWithTDataOnResultSuccess()
        {
            //Given
            int givenValue = 15;
            int expected = 16;

            Result<int, Exception> succededResult = CreateSuccededResult<int, Exception>(givenValue);

            //When
            succededResult.OnSuccess((data) => { givenValue = data + 1; });

            //Then
            givenValue.ShouldBe(expected);
        }

        [Fact]
        public void OnSuccess_ShouldNotInvokeActionWithTDataOnResultFailure()
        {
            //Given
            int value = 15;
            int expected = 15;

            Result<int, Exception> failedResult = CreateFailedResult<int, Exception>(new Exception());

            //When
            failedResult.OnSuccess((data) => { value = data + 1; });

            //Then
            value.ShouldBe(expected);
        }
    }
}
