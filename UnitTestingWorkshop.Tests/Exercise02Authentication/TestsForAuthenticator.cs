using FakeItEasy;
using FluentAssertions;
using UnitTestingWorkshop.Core.Exercise02Authentication;
using Xunit;

namespace UnitTestingWorkshop.Tests.Exercise02Authentication
{
    public class TestsForAuthenticator
    {
        private readonly Authenticator _authenticator;
        private readonly IUserNamePasswordValidator _userNamePasswordValidator;
        private readonly ITwoFactorCodeGenerator _twoFactorCodeGenerator;
        private readonly ISmsSender _smsSender;

        public TestsForAuthenticator()
        {
            _userNamePasswordValidator = A.Fake<IUserNamePasswordValidator>();
            _twoFactorCodeGenerator = A.Fake<ITwoFactorCodeGenerator>();
            _smsSender = A.Fake<ISmsSender>();
            
            _authenticator = new Authenticator(
                _userNamePasswordValidator,
                _twoFactorCodeGenerator,
                _smsSender);
        }

        public class TestsForAuthenticate : TestsForAuthenticator
        {
            private readonly string _userName;
            private readonly string _password;
            private readonly User _user;

            public TestsForAuthenticate()
            {
                _userName = "johnny";
                _password = "hunter2";
                _user = new User
                {
                    UserName = _userName,
                    PhoneNumber = "0123 45 56 78"
                };
            }
            
            [Fact]
            public void ShouldReturnInvalidWhenUserNamePasswordCombinationIsWrong()
            {
                // Arrange
                A.CallTo(() => _userNamePasswordValidator.Validate(_userName, _password))
                    .Returns(new InvalidUserNamePassword());

                // Act
                var authenticationResult = _authenticator.Authenticate(_userName, _password);

                // Assert
                authenticationResult.Should().Be(AuthenticationResult.InvalidUsernamePassword);
            }

            [Fact]
            public void ShouldNotSendSmsWhenUserNamePasswordCombinationIsWrong()
            {
                // Arrange
                A.CallTo(() => _userNamePasswordValidator.Validate(_userName, _password))
                    .Returns(new InvalidUserNamePassword());

                // Act
                _authenticator.Authenticate(_userName, _password);

                // Assert
                A.CallTo(() => _smsSender.Send(A<string>._, A<string>._)).MustNotHaveHappened();
            }

            [Fact]
            public void ShouldReturnTwoFactorInitiatedWhenUserNamePasswordCombinationIsCorrect()
            {
                // Arrange
                A.CallTo(() => _userNamePasswordValidator.Validate(_userName, _password))
                    .Returns(new ValidUserNamePassword(_user));

                // Act
                var authenticationResult = _authenticator.Authenticate(_userName, _password);

                // Assert
                authenticationResult.Should().Be(AuthenticationResult.TwoFactorAuthenticationViaSmsInitiated);
            }

            [Fact]
            public void ShouldSendGeneratedCodeViaSmsWhenUserNamePasswordCombinationIsCorrect()
            {
                // Arrange
                A.CallTo(() => _userNamePasswordValidator.Validate(_userName, _password))
                    .Returns(new ValidUserNamePassword(_user));
                var twoFactorCode = "CODE123";
                A.CallTo(() => _twoFactorCodeGenerator.Generate())
                    .Returns(twoFactorCode);

                // Act
                _authenticator.Authenticate(_userName, _password);

                // Assert
                A.CallTo(() => _smsSender.Send(_user.PhoneNumber, twoFactorCode)).MustHaveHappened();
            }
        }
    }
}
