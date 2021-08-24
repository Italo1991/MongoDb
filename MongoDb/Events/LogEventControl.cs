namespace MongoDb.Events
{
    public class LogEventControl
    {
        public LogEventControl()
        {
            Pendente = true;
        }

        public bool Pendente { get; set; }
    }
}
