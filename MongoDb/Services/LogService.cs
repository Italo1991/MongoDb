using Microsoft.Extensions.Configuration;
using MongoDb.Events;
using MongoDb.Interfaces;
using MongoDB.Driver;

namespace MongoDb.Services
{
    public class LogService : BaseService<LogEvent>, ILogService
    {
        public LogService(IConfiguration configuration) : base(configuration)
        {
            
        }

        public LogEvent FindPending()
        {
            return _mongoCollection
                    .Find(entity => entity.LogEventControl.Pending == true).FirstOrDefault();
        }
    }
}
