using JobPortal.Application.Abstractions;

namespace JobPortal.Application.Errors
{
    public class AuthErrors
    {
        public static Error AlreadyRegistered => new Error("Auth.AlreadyRegistered", "Email already Registerd.");
        public static Error InvalidUserOrPassword => new Error("Auth.InvalidUserOrPassword", "Invalid User Or Password.");
        public static Error WrongPassword => new Error("Auth.WrongPassword", "Invalid Email or Password.");
    }
}
