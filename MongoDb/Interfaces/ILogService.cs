using MongoDb.Events;

namespace MongoDb.Interfaces
{
    public interface ILogService : IBaseService<LogEvent>
    {
        LogEvent FindPending();
    }
}
