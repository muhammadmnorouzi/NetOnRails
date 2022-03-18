using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class OnSuccessTests : TestBase
    {
        [Fact]
        public void ShouldReturnSameResult()
        {
            //Given
            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(new object());

            //When
            Result<object, Exception> result = succededResult.OnSuccess((_) => { });

            //Then
            result.ShouldBe(succededResult);
        }

        [Fact]
        public void ShouldInvokeActionOnResultSuccess()
        {
            //Given
            object givenValue = new();
            object expected = givenValue;
            object paramValue = default(object)!;

            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(givenValue);

            //When
            succededResult.OnSuccess((@object) => { paramValue = @object; });

            //Then
            paramValue.ShouldBe(expected);
        }

        [Fact]
        public void ShouldNotInvokeActionOnResultFailure()
        {
            //Given
            bool actionInvoked = false;
            bool expected = false;

            Result<object, Exception> failedResult = CreateFailedResult<object, Exception>(new Exception());

            //When
            failedResult.OnSuccess((_) => { actionInvoked = true; });

            //Then
            actionInvoked.ShouldBe(expected);
        }
    }
}
