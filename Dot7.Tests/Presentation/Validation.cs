using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWeb.Extensions;
using FluentAssertions;
namespace Dot7.Tests.Presentation
{
    public class Validation
    {
        [Theory]
        [InlineData("+989121234567",true)]
        [InlineData("+982188776655",false)]
        [InlineData("+16156381234", true)]
        void Should_Validate_Phones(string phoneNumber,bool expectation)
        {
            bool isValidPhoneNumber = phoneNumber.IsValidPhone();
            isValidPhoneNumber.Should().Be(expectation);
        }
    }
}
