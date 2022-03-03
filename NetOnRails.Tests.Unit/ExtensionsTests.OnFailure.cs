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

            Result<object, Exception> failedResult = CreateFailedResult<object, Exception>(exc);

            //When
            failedResult.OnFailure(() => { actionInvoked = true; });

            //Then
            actionInvoked.ShouldBe(expected);
        }

        [Fact]
        public void OnFailure_ShouldNotInvokeActionOnResultSuccess()
        {
            //Given
            bool actiondInvoked = false;
            bool expected = false;

            object obj = new object();
            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(obj);

            //When
            succededResult.OnFailure(() => { actiondInvoked = true; });

            //Then
            actiondInvoked.ShouldBe(expected);
        }

        [Fact]
        public void OnFailure_ShouldInvokeActionWithTDataOnResultFailure()
        {
            //Given
            string errorMessage = "This is fault report.";
            Exception exc = new Exception(errorMessage);
            Exception expected = exc;
            Exception actionParameter = default(Exception)!;

            Result<object, Exception> failedResult = CreateFailedResult<object, Exception>(exc);

            //When
            failedResult.OnFailure((exception) => { actionParameter = exception; });

            //Then
            actionParameter.ShouldBe(expected);
        }

        [Fact]
        public void OnFailure_ShouldNotInvokeActionWithTDataOnResultSuccess()
        {
            //Given
            object obj = new object();
            bool expected = false;
            bool actionInvoked = false;

            Result<object, Exception> succededResult = CreateSuccededResult<object, Exception>(obj);

            //When
            succededResult.OnFailure((exception) => { actionInvoked = true; });

            //Then
            actionInvoked.ShouldBe(expected);
        }
    }
}