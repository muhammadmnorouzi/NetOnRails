using System;
using Xunit;
using Shouldly;

namespace NetOnRails.Tests.Unit
{
    public class HelperTests : TestBase
    {
        [Fact]
        public void ResultShouldHaveProperValuesWhenIsSucceded()
        {
            var obj = new object();

            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(obj);

            succededResult.IsSuccess.ShouldBe(true);
            succededResult.IsFailure.ShouldBe(false);
            succededResult.Error.ShouldBeNull();
            succededResult.Value.ShouldBe(obj);
        }

        [Fact]
        public void ResultShouldHaveProperValuesWhenIsFailed()
        {
            var exc = new Exception();

            Result<object, Exception> succededResult = CreateFailedResult<object, Exception>(exc);

            succededResult.IsSuccess.ShouldBe(false);
            succededResult.IsFailure.ShouldBe(true);
            succededResult.Error.ShouldBe(exc);
            succededResult.Value.ShouldBeNull();
        }
    }
}