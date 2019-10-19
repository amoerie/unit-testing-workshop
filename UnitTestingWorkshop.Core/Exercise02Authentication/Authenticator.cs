namespace UnitTestingWorkshop.Core.Exercise02SMS
{
    public interface IAuthenticator
    {
        AuthenticationResult Authenticate(string username, string password);
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

        public AuthenticationResult Authenticate(string username, string password)
        {
            if (!_userNamePasswordValidator.TryValidate(username, password, out var user))
                return AuthenticationResult.InvalidUsernamePassword;

            var twoFactorCode = _twoFactorCodeGenerator.Generate();

            _smsSender.Send(user.PhoneNumber, twoFactorCode);

            return AuthenticationResult.TwoFactorAuthenticationViaSmsInitiated;
        }
    }
}
