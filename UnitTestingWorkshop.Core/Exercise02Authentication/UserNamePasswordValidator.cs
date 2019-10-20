using System;

namespace UnitTestingWorkshop.Core.Exercise02Authentication
{
    public interface IUserNamePasswordValidator
    {
        ValidationResult Validate(string username, string password);
    }
    
    public abstract class ValidationResult {}

    public class InvalidUserNamePassword : ValidationResult
    {
        public InvalidUserNamePassword() {}
    }

    public class ValidUserNamePassword : ValidationResult
    {
        public User User { get; set; }

        public ValidUserNamePassword(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}