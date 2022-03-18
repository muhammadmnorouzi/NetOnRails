using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public class MapTests : TestBase
    {
        [Fact]
        public void ShouldMapOnResultSuccess()
        {
            //Given
            object givenValue = new();
            string expectedData = givenValue.GetHashCode().ToString();
            Result<object, Exception> givenResult = CreateSuccededResult<object, Exception>(givenValue);

            //When
            Result<string, Exception> mapedResult = givenResult.Map(
                (data) => data.GetHashCode().ToString());

            //Then
            mapedResult.Value.ShouldBe(expectedData);
            mapedResult.Error.ShouldBe(default(Exception));
        }

        [Fact]
        public void ShouldMapOnResultFailure()
        {
            //Given
            Exception givenError = new Exception();
            Exception expectedError = givenError;
            Result<object, Exception> givenResult = CreateFailedResult<object, Exception>(givenError);

            //When
            Result<string, Exception> mapedResult = givenResult.Map(
                (data) => data.GetHashCode().ToString());

            //Then
            mapedResult.Value.ShouldBe(default(string));
            mapedResult.Error.ShouldBe(expectedError);
        }
    }
}