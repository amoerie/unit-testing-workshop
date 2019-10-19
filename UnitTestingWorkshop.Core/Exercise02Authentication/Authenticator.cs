using System;

namespace UnitTestingWorkshop.Core.Exercise02SMS
{
    public interface IAuthenticator
    {
        AuthenticationResult Authenticate(string userName, string password);
    }

    public class Authenticator : IAuthenticator
    {
        private readonly IUserNamePasswordValidator _userNamePasswordValidator;
        private readonly ITwoFactorCodeGenerator _twoFactorCodeGenerator;
        private readonly ISmsSender _smsSender;

        public Authenticator(
            IUserNamePasswordValidator userNamePasswordValidator,
            ITwoFactorCodeGenerator twoFactorCodeGenerator,
            ISmsSender smsSender)
        {
            _userNamePasswordValidator = userNamePasswordValidator;
            _twoFactorCodeGenerator = twoFactorCodeGenerator;
            _smsSender = smsSender;
        }

        public AuthenticationResult Authenticate(string userName, string password)
        {
            var validationResult = _userNamePasswordValidator.Validate(userName, password);
            if(validationResult is InvalidUserNamePassword)
                return AuthenticationResult.InvalidUsernamePassword;

            if (validationResult is ValidUserNamePassword validUserNamePassword)
            {
                var user = validUserNamePassword.User;
                var twoFactorCode = _twoFactorCodeGenerator.Generate();

                _smsSender.Send(user.PhoneNumber, twoFactorCode);

                return AuthenticationResult.TwoFactorAuthenticationViaSmsInitiated;
            }
            
            throw new Exception("Unknown validation result: " + validationResult.GetType());
        }
    }
}
