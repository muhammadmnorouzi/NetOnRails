using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class HelperTests : TestBase
    {
        [Fact]
        public void ResultShouldHaveProperValuesWhenIsSucceded()
        {
            object givenValue = new();

            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(givenValue);

            succededResult.IsSuccess.ShouldBe(true);
            succededResult.IsFailure.ShouldBe(false);
            succededResult.Error.ShouldBeNull();
            succededResult.Value.ShouldBe(givenValue);
        }

        [Fact]
        public void ResultShouldHaveProperValuesWhenIsFailed()
        {
            Exception givenError = new();

            Result<object, Exception> succededResult = CreateFailedResult<object, Exception>(givenError);

            succededResult.IsSuccess.ShouldBe(false);
            succededResult.IsFailure.ShouldBe(true);
            succededResult.Error.ShouldBe(givenError);
            succededResult.Value.ShouldBe(default(object));
        }
    }
}