using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MyFirtWebApi.Helpers
{
    public static class SMSHelper
    {
        public static void SendSMS(string phoneNumer, string body)
        {
            TwilioClient.Init(SMSApiKeys.AccountSid, SMSApiKeys.AuthToken);

            MessageResource message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(SMSApiKeys.FromPhone),
                to: new Twilio.Types.PhoneNumber(phoneNumer));

            Console.WriteLine(message.Sid);
        }
    }
}