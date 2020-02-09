using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public static class SMSHelper
{
    public static void SendSMS(string phoneNumer, string body)
    {
        // Find your Account Sid and Token at twilio.com/console
        // DANGER! This is insecure. See http://twil.io/secure
        const string accountSid = "AC2ce075ad895e5f95e590fb1e3916a72c";
        const string authToken = "315e146a0a9cf831dbc4cc9f1738c3f6";

        TwilioClient.Init(accountSid, authToken);

        MessageResource message = MessageResource.Create(
            body: body,
            from: new Twilio.Types.PhoneNumber("+13073170520"),
            to: new Twilio.Types.PhoneNumber(phoneNumer));

        Console.WriteLine(message.Sid);
    }
}