using CustomAttributes.Attributes;
using System;

namespace CustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "email@gmail.com";
            uint number = 666777888;
            string message = "Sample massages";

            Sender sendEmail = new Sender(email, message);
            Sender SendSMS = new Sender(number, message);
            Sender SendAll = new Sender(email, number, message);
        }
    }
}
