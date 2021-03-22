namespace LogViewer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LogGrid.xaml
    /// </summary>
    public partial class LogGrid
    {
        public LogGrid()
        {
            InitializeComponent();
        }

        public void CarregarArquivo(string arquivo)
        {
            try
            {
                using (var fs = File.Open(arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var bs = new BufferedStream(fs))
                using (var sr = new StreamReader(bs, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        AdicionarLinha(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao carregar o arquivo {arquivo}.\n{ex}");
            }

            StatusArquivo.Content = arquivo;
            StatusLinhas.Content = $"{Rows.Count} linhas";
            GridControl.ItemsSource = Rows;
        }

        private List<LogRow> Rows { get; } = new List<LogRow>();
        private char[] Separadores { get; set; } = { '|' };

        private void AdicionarLinha(string line)
        {
            var fields = line.Split(Separadores, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length < 4)
            {
                if (Rows.Count > 0)
                    Rows.Last().Info += Environment.NewLine + line;

                return;
            }

            var info = fields[4];
            if (fields.Length > 5)
                info += Environment.NewLine + fields[5];

            var logRow = new LogRow()
            {
                DateTime = DateTime.Parse(fields[0]),
                Logger = fields[1],
                Level = fields[2],
                ThreadId = int.Parse(fields[3]),
                Info = info
            };

            Rows.Add(logRow);
        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            var detalhes = new Detalhes(Window.GetWindow(this), GridControl.GetFocusedRowCellValue("Info").ToString());
            detalhes.ShowDialog();
        }
    }
}
