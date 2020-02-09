using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public static class SMSHelper
{
    public static void SendSMS(string phoneNumer, string body)
    {
        // Find your Account Sid and Token at twilio.com/console
        // DANGER! This is insecure. See http://twil.io/secure

        TwilioClient.Init(accountSid, authToken);

        MessageResource message = MessageResource.Create(
            body: body,
            from: new Twilio.Types.PhoneNumber("+13073170520"),
            to: new Twilio.Types.PhoneNumber(phoneNumer));

        Console.WriteLine(message.Sid);
    }
}