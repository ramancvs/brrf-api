using MongoDB.Driver;
using System;
using Newtonsoft.Json;
using BRRF.Core.BusinessManager.Interface;

namespace BRRF.Common
{
    public class AuditHandler : IAuditHandler
    {
        /// <summary>
        /// Audit command payload
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICommand command)
        {
            Audit audit
                = new Audit
                {
                    DateTime = DateTime.Now,
                    Message =JsonConvert.SerializeObject(command)

                };
            saveAuditMessage(audit);
        }

        /// <summary>
        /// Audit query payload.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        public void Execute<TResult>(IQuery<TResult> query)
        {
            Audit audit
                = new Audit
                {
                    DateTime = DateTime.Now,
                    Message = Newtonsoft.Json.JsonConvert.SerializeObject(query)
                };
            saveAuditMessage(audit);
        }

        public void saveAuditMessage(Audit audit)
        {
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("test");
            var collection = DB.GetCollection<Audit>("Audit");
            collection.InsertOneAsync(audit);
        }
    }
    public class Audit
    {
        /// <summary>
        /// Sets or Gets Audit record date
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Payload in string format to be audited
        /// </summary>
        public string Message { get; set; }
    }
}
