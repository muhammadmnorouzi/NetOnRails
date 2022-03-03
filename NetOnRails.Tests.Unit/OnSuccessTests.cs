using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class OnSuccess : TestBase
    {
        [Fact]
        public void ShouldReturnSameResultWithoutParameters()
        {
            //Given
            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(new object());

            //When
            Result<object, Exception> result = succededResult.OnSuccess(() => { });

            //Then
            result.ShouldBe(succededResult);
        }

        [Fact]
        public void ShouldReturnSameResultWithParameters()
        {
            //Given
            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(new object());

            //When
            Result<object, Exception> result = succededResult.OnSuccess((obj) => { });

            //Then
            result.ShouldBe(succededResult);
        }

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

            Result<int, Exception> failedResult = CreateFailedResult<int, Exception>(new Exception());

            //When
            failedResult.OnSuccess(() => { value = value + 1; });

            //Then
            value.ShouldBe(expected);
        }

        [Fact]
        public void ShouldInvokeActionWithTDataOnResultSuccess()
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
        public void ShouldNotInvokeActionWithTDataOnResultFailure()
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
