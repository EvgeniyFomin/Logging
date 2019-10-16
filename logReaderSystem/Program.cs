using logReaderSystem.eventLogs;
using LogReaderSystem.msmq;
using System;
using System.Messaging;
using msmq.eventLogs;

namespace LogReaderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var events = SSISTxtLogReader.GetAllEventLogs();
            

            // //string path = @".\Private$\SomeTestName";
            string path = "FormatName:Direct=TCP:10.10.42.208\\nixQueue";

            MessageQueue messageQueue = null;
            // //if (MessageQueue.Exists(path))
            // //{
            // //    messageQueue = new MessageQueue(path);
            // //    messageQueue.Label = "Existing queue";
            // //}
            // //else
            // //{
            // //    // Create the Queue
            // //    MessageQueue.Create(path);
            // //    messageQueue = new MessageQueue(path);
            // //    messageQueue.Label = "Newly Created Queue";
            // //}
            messageQueue = new MessageQueue(path);
            MessageWriter mswrtr = new MessageWriter(messageQueue);
            EventLogReader eventReader = new EventLogReader();
            var msg = eventReader.ReadEventLog(1);
            mswrtr.WriteMessage(msg);

            // //mswrtr.WriteMessage("That's awesome to work with MSMQ");
            // for (int i = 0; i <= 20; i++)
            // {
            //     mswrtr.WriteMessage($"{i} message to check");
            // }


            MessageReader msrdr = new MessageReader(messageQueue);

            msrdr.ReadMessageToConsole();
            // EventLogReader.ReadAllEventLogs();

        }
    }
}
