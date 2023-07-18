using libphonenumber;
using System.Net;
using System.Text.RegularExpressions;
using static com.google.i18n.phonenumbers.PhoneNumberUtil;

namespace BlazorWeb.Extensions
{
    public static class PhoneNumberValidator
    {
        public static bool IsValidPhone(this string _phoneNumber)
        {
            var phoneUtil = com.google.i18n.phonenumbers.PhoneNumberUtil.getInstance();
            try
            {
                string telephoneNumber = _phoneNumber;
                string countryCode = "IR";
                var phoneNumber = phoneUtil.parse(telephoneNumber, countryCode);
                return phoneUtil.isValidNumber(phoneNumber);
            }
            catch (NumberParseException ex)
            {

                return false;

            }
        }

    }
}
