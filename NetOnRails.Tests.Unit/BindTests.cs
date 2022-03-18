using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class BindTests : TestBase
    {
        [Fact]
        public void ShouldBindOnResultSuccess()
        {
            //Given 
            object givenValue = new();
            string expected = givenValue.GetHashCode().ToString();

            Result<object, Exception> result = CreateSuccededResult<object, Exception>(givenValue);

            //When
            Result<string, Exception> binded = result
                .Bind((data) => CreateSuccededResult<string, Exception>(
                    data.GetHashCode().ToString()));

            //Then
            binded.Value.ShouldBe(expected);
            binded.Error.ShouldBe(default(Exception));
        }

        [Fact]
        public void ShouldBindOnResultFailure()
        {
            //Given 
            Exception givenError = new();
            Exception expected = givenError;

            Result<object, Exception> result = CreateFailedResult<object, Exception>(givenError);

            //When
            Result<string, Exception> binded = result
                .Bind((data) => CreateSuccededResult<string, Exception>(data.ToString()!));

            //Then
            binded.Value.ShouldBe(default(string));
            binded.Error.ShouldBe(expected);
        }
    }
}