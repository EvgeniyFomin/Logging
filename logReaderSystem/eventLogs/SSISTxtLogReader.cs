using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using msmq.msmq;

namespace msmq.eventLogs
{
    public static class SSISTxtLogReader
    {
        static readonly string NormalizationLogName = "Normalization";
        static readonly string MovePeriodLogName = "MoveReportPeriodSet";
        static readonly string LogBackupPrefix = "backup_";
        static readonly string[] DCDBSETNames = new string[] { "DCDBSET1", "DCDBSET2", "DCDBSET3", "DCDBSET4" };

        public static List<SSISEventModel> GetAllEventLogs()
        {
            List<string> allEvents = new List<string>();

            foreach (var dcdbsetName in DCDBSETNames)
            {
                List<string> dcdbsetEvents = new List<string>();
                allEvents.AddRange(RetrieveLogFromFile(MovePeriodLogName, dcdbsetName).Select(ev => $"{dcdbsetName},{ev}"));
                allEvents.AddRange(RetrieveLogFromFile(NormalizationLogName, dcdbsetName).Select(ev => $"{dcdbsetName},{ev}"));
            }
            return allEvents.Select(ev => ModelMapper.CSVLineToSSISModel(ev)).ToList();
        }

        private static List<string> RetrieveLogFromFile(string logName, string dcdbsetName)
        {
            List<string> events = new List<string>();
            string SSISRepositoryPath = ConfigurationManager.AppSettings["SSISRepositoryPath"];
            string logPath = Path.Combine(SSISRepositoryPath, $"{logName}_{dcdbsetName}.log");
            string logBackupPath = Path.Combine(SSISRepositoryPath, $"{LogBackupPrefix}{logName}_{dcdbsetName}.log");
            events = File.ReadAllLines(logPath)
                .ToList()
                .FindAll(line => 
                    !line.StartsWith("#Fields") & 
                    line != "");
            File.AppendAllLines(logBackupPath, events);
            File.Delete(logPath);
            return events;
        }
    }
}
