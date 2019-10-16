using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msmq.eventLogs
{
    public class SSISEventModel
    {
        public int ID { get; set; }
        public string DcdbsetName { get; set; }
        public string EventName { get; set; }
        public string Computer { get; set; }
        public string Operator { get; set; }
        public string Source { get; set; }
        public string SourceID { get; set; }
        public string ExecutionID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DataCode { get; set; }
        public string DataBytes { get; set; }
        public string Message { get; set; }
    }
}
