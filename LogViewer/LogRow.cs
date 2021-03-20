namespace LogViewer
{
    using System;

    public class LogRow
    {
        public DateTime DateTime { get; set; }
        public string Logger { get; set; }
        public string Level { get; set; }
        public int ThreadId { get; set; }
        public string Info { get; set; }
    }
}
