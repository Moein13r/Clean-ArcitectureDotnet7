using System.Text.RegularExpressions;

namespace BlazorWeb.Extensions
{
    public static class BankCardNumberValidator
    {
        public static bool IsValidBankCardNumber(this long bankCardNumber)
        {
            Regex card = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var cardNumber = bankCardNumber.ToString();
            return card.IsMatch(cardNumber);            
        }
    }
}
