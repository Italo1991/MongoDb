namespace MongoDb.Events
{
    public class LogEventControl
    {
        public LogEventControl()
        {
            Pending = true;
        }

        public bool Pending { get; set; }
    }
}
