using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class OnFailureTests : TestBase
    {
        [Fact]
        public void ShouldReturnSameResult()
        {
            //Given
            Result<object, Exception> failedResult = CreateFailedResult<object, Exception>(new Exception());

            //When
            Result<object, Exception> result = failedResult.OnFailure((_) => { });

            //Then
            result.ShouldBe(failedResult);
        }

        [Fact]
        public void ShouldInvokeActionOnResultFailure()
        {
            //Given
            Exception exc = new Exception("This is failure report.");
            Exception expected = exc;
            Exception paramValue = default(Exception)!;

            Result<object, Exception> failedResult = CreateFailedResult<object, Exception>(exc);

            //When
            failedResult.OnFailure((exception) => { paramValue = exception; });

            //Then
            paramValue.ShouldBe(expected);
        }

        [Fact]
        public void ShouldNotInvokeActionOnResultSuccess()
        {
            //Given
            bool actiondInvoked = false;
            bool expected = false;

            object obj = new();
            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(obj);

            //When
            succededResult.OnFailure((_) => { actiondInvoked = true; });

            //Then
            actiondInvoked.ShouldBe(expected);
        }
    }
}