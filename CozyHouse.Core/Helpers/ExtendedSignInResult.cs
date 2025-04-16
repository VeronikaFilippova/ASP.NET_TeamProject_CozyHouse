using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.Helpers
{
    /// <summary>
    /// Represents a wrapper around <see cref="SignInResult"/> that includes an optional message, 
    /// typically used to convey error details when sign-in fails.
    /// </summary>
    public class ExtendedSignInResult
    {
        public SignInResult Result { get; set; }
        public string Message { get; set; }
        public ExtendedSignInResult(SignInResult result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
