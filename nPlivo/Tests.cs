using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Xunit;

namespace nPlivo
{
    public class Tests : TestConfig
    {
        [Fact(DisplayName = "Invalid Auth ID/token combo throws")]
        public void Invalid_auth_values_throws()
        {
            var client = new Client("12345", "ABCDE");
            client.SendSms(PhoneNumberVirtual, PhoneNumberReal, "Test helloo plivoooo");
        }

        [Fact]        
        public void CanSent()
        {
            var client = new Client(AuthId, AuthToken);
            client.SendSms(PhoneNumberVirtual, PhoneNumberReal, "Test helloo plivoooo");
        }
    }
}
