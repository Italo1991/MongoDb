using System;

namespace MongoDb.Events
{
    public class LogEvent : TEntity
    {
        public LogEvent()
        {
            DataCriacao = DateTime.Now;
            LogEventControl = new LogEventControl();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public LogEventControl LogEventControl { get; set; }
    }
}
