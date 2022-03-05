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
            object obj = new object();
            string expected = obj.GetHashCode().ToString();

            Result<object, Exception> result = CreateSuccededResult<object, Exception>(obj);

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
            Exception exc = new Exception();
            Exception expected = exc;

            Result<object, Exception> result = CreateFailedResult<object, Exception>(exc);

            //When
            Result<string, Exception> binded = result
                .Bind((data) => CreateSuccededResult<string, Exception>(data.ToString()!));

            //Then
            binded.Value.ShouldBe(default(string));
            binded.Error.ShouldBe(expected);
        }
    }
}