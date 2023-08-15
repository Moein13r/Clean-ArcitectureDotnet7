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
                //string countryCode = "IR";
                var phoneNumber = phoneUtil.parse(telephoneNumber, null);
                string phoneNumberType = phoneUtil.getNumberType(phoneNumber).ToString();

                return !string.IsNullOrEmpty(phoneNumberType) && (phoneNumberType == "MOBILE" || phoneNumberType == "FIXED_LINE_OR_MOBILE");
                //return phoneUtil.isValidNumber(phoneNumber);
            }
            catch (NumberParseException ex)
            {

                return false;

            }
        }

    }
}
