using System;

namespace MongoDb.Events
{
    public class LogEvent : TEntity
    {
        public LogEvent(string description, string name)
        {
            Description = description;
            Name = name;
            CreationDate = DateTime.Now;
            LogEventControl = new LogEventControl();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }

        public LogEventControl LogEventControl { get; set; }

        public void SetResolved()
        {
            LogEventControl.Pending = false;
        }
    }
}
