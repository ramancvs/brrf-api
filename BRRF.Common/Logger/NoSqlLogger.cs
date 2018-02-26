using BRRF.Core.BusinessManager.Interface;
using MongoDB.Driver;

namespace BRRF.Common
{
    /// <summary>
    /// This class logs information to a nosql database
    /// </summary>
    public class NoSqlLogger : ILogger
    {
        public void ProcessLogMessage<TLog>(TLog log)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            var symbolcollection = database.GetCollection<TLog>("Logs");
            symbolcollection.InsertOne(log);
        }
    }
}
