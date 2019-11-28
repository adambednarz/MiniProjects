using CustomAttributes.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes
{

    [DebugInfo(100, "Adam", "20.11.2019", Message = "Class is uncompleted")]
    public class Sender
    {
        public bool IsEmailSend { get; set; } = false;
        public bool IsSMSSend { get; set; } = false;

        public Sender(string email, string message)
        {
            EmailSender(email, message);
        }
        public Sender(uint number, string message)
        {
            SMSSender(number, message);
        }
        [DebugInfo(105, "Adam", "20.11.2019", Message = "Constructor can not be invoke because sender methods are uncompleated ")]
        public Sender(string email, uint number, string message)
        {
            EmailSender(email, message);
            SMSSender(number, message);
        }
        [DebugInfo(200, "Karol", "40.11.2019", Message = "Sender does not return any information if the message was correctly send.")]
        public void EmailSender(string email, string message)
        {
            //IsEmailSend = true;
        }
        [DebugInfo(101, "Paweł", "10.11.2019", Message = "Sender is uncompleted")]
        public void SMSSender(uint number, string message)
        {
            IsSMSSend = true;
        }
    }
}
