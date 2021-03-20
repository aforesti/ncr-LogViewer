namespace LogViewer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Log
    {
        public List<LogRow> Rows { get; } = new List<LogRow>();

        public Log(string arquivo)
        {
            var log = File.ReadAllLines(arquivo, Encoding.Default);
            foreach (var line in log)
                AdicionarLinha(line);
        }

        private void AdicionarLinha(string line)
        {
            var fields = line.Split('|');
            if (fields.Length < 4)
            {
                if (Rows.Count > 0)
                    Rows.Last().Info += Environment.NewLine + line;

                return;
            }

            var logRow = new LogRow()
            {
                DateTime = DateTime.Parse(fields[0]),
                Logger = fields[1],
                Level = fields[2],
                ThreadId = int.Parse(fields[3]),
                Info = fields[4]
            };

            Rows.Add(logRow);
        }
    }
}