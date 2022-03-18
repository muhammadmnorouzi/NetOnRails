using System.Runtime.InteropServices;
using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class DoubleMapTests : TestBase
    {
        [Fact]
        public void ShouldExecuteOnSuccessOnResultSuccess()
        {
            //Given 
            object obj = new object();
            int expectedHashCode = obj.GetHashCode();
            bool onFailureExecuted = false;

            Result<object, Exception> result = CreateSuccededResult<object, Exception>(obj);

            //When
            Result<int, Exception> doubleMapResult = result
                .DoubleMap(
                    onSuccess: (input) => input.GetHashCode(),
                    onFailure: (_) => onFailureExecuted = true
                    );

            //Then
            doubleMapResult.Value.ShouldBe(expectedHashCode);
            doubleMapResult.Error.ShouldBe(default(Exception));
            onFailureExecuted.ShouldBe(false);
        }
    }
}