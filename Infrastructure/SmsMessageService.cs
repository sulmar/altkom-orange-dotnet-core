using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class SmsMessageService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"sending sms {message}");
        }
    }

    public class EmailMessageService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"sending email {message}");
        }
    }
}
