using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogReaderSystem.msmq
{
    class MessageReader
    {
        private MessageQueue msmq;

        public MessageReader(MessageQueue msmq)
        {
            this.msmq = msmq;
        }

        public void ReadMessageToConsole()
        {
            Console.WriteLine("Getting all messages...");
            Message[] messages = this.msmq.GetAllMessages();
            //Console.WriteLine($"Queue label = {this.msmq.Label}, sender pc name = fpfasfjk");
            Console.WriteLine($"Found {messages.Count()} messages");
            foreach (Message msg in messages)
            {
                if (messages.Count() > 0)
                    Console.WriteLine($"Body = {msg.Body}, label = {msg.Label}");
                break;
            }
            // msmq.Purge();
        }
    }
}
