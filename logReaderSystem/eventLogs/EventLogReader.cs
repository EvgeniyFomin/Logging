using LogReaderSystem.msmq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logReaderSystem.eventLogs
{
    class EventLogReader
    {
        private EventLog log;
        public EventLogReader()
        {
            this.log = new EventLog("Security");
        }

        public void ReadAllEventLogsToConsole()
        {
            for (var i = 0; i <= 3; i++)
            {
                var a = this.log.Entries.Cast<EventLogEntry>().ToList()[i];
                Console.WriteLine(a.Source);
            }
        }
        public string ReadEventLog(int number)
        {
            if (log.Entries.Count >= number)
            {
                foreach (var entry in log.Entries.Cast<EventLogEntry>())
                {
                    if (number == 0)
                        return entry.Message;
                    else
                        number--;
                }
                return String.Empty;
            }
            else return String.Empty;
        }
    }
}
