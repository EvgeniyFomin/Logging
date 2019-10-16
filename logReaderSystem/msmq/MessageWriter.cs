﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogReaderSystem.msmq
{
    class MessageWriter
    {
        private MessageQueue msmq;

        public MessageWriter(MessageQueue msmq)
        {
            this.msmq = msmq;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine("Sending message to queue");
            this.msmq.Send(message, "ololabel");
        }

    }
}
