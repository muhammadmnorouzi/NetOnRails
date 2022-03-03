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

            Result<object, Exception> succededResult =
                CreateSuccededResult<object, Exception>(obj);

            succededResult.IsSuccess.ShouldBe(true);
            succededResult.IsFailure.ShouldBe(false);
            succededResult.Error.ShouldBeNull();
            succededResult.Value.ShouldBe(obj);
        }
    }
}