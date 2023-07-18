using System.Net.Mail;

namespace BlazorWeb.Extensions
{
    public static class RegexEmailValidator
    {
        public static bool IsValidEmail(this string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
