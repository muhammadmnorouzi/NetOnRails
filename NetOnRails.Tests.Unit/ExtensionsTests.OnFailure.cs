using System;
using Shouldly;
using Xunit;

namespace NetOnRails.Tests.Unit
{
    public partial class ExtensionsTests
    {
        [Fact]
        public void OnFailure_ShouldInvokeActionOnResultFailure()
        {
            //Given
            Exception exc = new Exception("This is failure report.");
            bool actionInvoked = false;
            bool expected = true;

            Result<object, Exception> succededResult = CreateFailedResult<object, Exception>(exc);

            //When
            succededResult.OnFailure(() => { actionInvoked = true; });

            //Then
            actionInvoked.ShouldBe(expected);
        }
        // 
        //         [Fact]
        //         public void ShouldNotInvokeActionOnResultFailure()
        //         {
        //             //Given
        //             int value = 15;
        //             int expected = 15;
        // 
        //             Result<int, Exception> succededResult = CreateFailedResult<int, Exception>(new Exception());
        // 
        //             //When
        //             succededResult.OnSuccess(() => { value = value + 1; });
        // 
        //             //Then
        //             value.ShouldBe(expected);
        //         }
        // 
        //         [Fact]
        //         public void ShouldInvokeActionWithTDataOnResultSuccess()
        //         {
        //             //Given
        //             int givenValue = 15;
        //             int expected = 16;
        // 
        //             Result<int, Exception> succededResult = CreateSuccededResult<int, Exception>(givenValue);
        // 
        //             //When
        //             succededResult.OnSuccess((data) => { givenValue = data + 1; });
        // 
        //             //Then
        //             givenValue.ShouldBe(expected);
        //         }
        // 
        //         [Fact]
        //         public void ShouldNotInvokeActionWithTDataOnResultFailure()
        //         {
        //             //Given
        //             int value = 15;
        //             int expected = 15;
        // 
        //             Result<int, Exception> succededResult = CreateFailedResult<int, Exception>(new Exception());
        // 
        //             //When
        //             succededResult.OnSuccess((data) => { value = data + 1; });
        // 
        //             //Then
        //             value.ShouldBe(expected);
        //         }
    }
}