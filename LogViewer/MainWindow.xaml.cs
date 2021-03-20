namespace LogViewer
{
    using System.IO;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CarregarArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
                return;

            Title = arquivo;
            var log = new Log(arquivo);
            GridControl.ItemsSource = log.Rows;
        }

        private void TableView_Drop(object sender, DragEventArgs e)
        {
            var arquivo = ((string[])e.Data.GetData(DataFormats.FileDrop, false))?.First();
            CarregarArquivo(arquivo);
        }
    }
}
