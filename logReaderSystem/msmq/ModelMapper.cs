using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using msmq.eventLogs;

namespace msmq.msmq
{
    public static class ModelMapper
    {
        public static SSISEventModel DataReaderToSSISModel(SqlDataReader dr)
        {
            SSISEventModel SSISEvent = new SSISEventModel();
            SSISEvent.ID = int.Parse(dr["id"].ToString());
            SSISEvent.EventName = dr["event"].ToString();
            SSISEvent.Computer = dr["computer"].ToString();
            SSISEvent.Operator = dr["operator"].ToString();
            SSISEvent.Source = dr["source"].ToString();
            SSISEvent.SourceID = dr["sourceid"].ToString();
            SSISEvent.ExecutionID = dr["executionid"].ToString();
            SSISEvent.StartTime = DateTime.Parse(dr["starttime"].ToString());
            SSISEvent.EndTime = DateTime.Parse(dr["endtime"].ToString());
            SSISEvent.Message = dr["message"].ToString();
            return SSISEvent;
        }

        public static SSISEventModel CSVLineToSSISModel(string eventLine)
        {            
            var eventColumns = eventLine.Split(',');
            if (eventColumns.Count() < typeof(SSISEventModel).GetProperties().Count() - 1)
                throw new Exception($"Number of columns in SSIS log file is less than number of fields in SSIS event model. Check formatting and try again. Line is: {eventLine}");
            SSISEventModel SSISEvent = new SSISEventModel
            {
                DcdbsetName = eventColumns[0],
                EventName = eventColumns[1],
                Computer = eventColumns[2],
                Operator = eventColumns[3],
                Source = eventColumns[4],
                SourceID = eventColumns[5],
                ExecutionID = eventColumns[6],
                StartTime = DateTime.Parse(eventColumns[7]),
                EndTime = DateTime.Parse(eventColumns[8]),
                DataCode = eventColumns[9],
                DataBytes = eventColumns[10],
                Message = eventColumns[11]
            };
            return SSISEvent;
        }
    }
}
