using MongoDb.Events;
using System;
using System.Collections.Generic;

namespace MongoDb.Interfaces
{
    public interface ILogService : IBaseService<LogEvent>
    {
        LogEvent FindPendente();
    }
}
