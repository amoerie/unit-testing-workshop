using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace UnitTestingWorkshop.Tests.Exercise02Authentication
{
    public class TestsForAuthenticator
    {
        public TestsForAuthenticator()
        {

        }

        public class TestsForAuthenticate : TestsForAuthenticator
        {
            [Fact]
            public void ShouldReturnInvalidWhenUserNamePasswordCombinationIsWrong()
            {
                // Arrange

                // Act

                // Assert
            }

            [Fact]
            public void ShouldNotSendSmsWhenUserNamePasswordCombinationIsWrong()
            {
                // Arrange

                // Act

                // Assert
            }

            [Fact]
            public void ShouldReturnTwoFactorInitiatedWhenUserNamePasswordCombinationIsCorrect()
            {
                // Arrange

                // Act

                // Assert
            }

            [Fact]
            public void ShouldSendGeneratedCodeViaSmsWhenUserNamePasswordCombinationIsCorrect()
            {
                // Arrange

                // Act

                // Assert
            }
        }
    }
}
