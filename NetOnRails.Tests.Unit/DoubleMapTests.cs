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

        [Fact]
        public void ShouldExecuteOnFailureOnResultFailure()
        {
            //Given 
            Exception givenError = new();
            int expectedHashCode = givenError.GetHashCode();
            bool onSuccessExecuted = false;
            bool onFailureExecuted = false;
            int errorHashCode = default(int);

            Result<object, Exception> result = CreateFailedResult<object, Exception>(givenError);

            //When
            Result<int, Exception> doubleMapResult = result
                .DoubleMap(
                    onSuccess: (_) =>
                    {
                        onSuccessExecuted = true;
                        return default(int);
                    },
                    onFailure: (error) =>
                    {
                        onFailureExecuted = true;
                        errorHashCode = errorHashCode.GetHashCode();
                    });

            //Then
            doubleMapResult.Value.ShouldBe(default(int));
            doubleMapResult.Error.ShouldBe(givenError);
            onFailureExecuted.ShouldBe(true);
            onSuccessExecuted.ShouldBe(false);
        }
    }
}