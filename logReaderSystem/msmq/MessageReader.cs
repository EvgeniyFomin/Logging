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
           var messages = this.msmq.GetAllMessages();
            //Console.WriteLine($"Queue label = {this.msmq.Label}, sender pc name = fpfasfjk");
            foreach (Message msg in messages)
            {
                if (messages.Count() > 0)
                    Console.WriteLine($"Body = {msg.Body}, label = {msg.Label}");
            }
            // msmq.Purge();
        }
    }
}
