namespace LogViewer
{
    using System.IO;
    using System.Windows;
    using DevExpress.Mvvm.Native;
    using DevExpress.Utils;
    using DevExpress.Xpf.Core;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CarregarArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
                return;

            var tabItem = new DXTabItem
            {
                Header = Path.GetFileName(arquivo),
                ToolTip = arquivo,
                AllowHide = DefaultBoolean.True
            };

            tabMain.Items.Add(tabItem);
            tabMain.SelectedIndex = tabMain.Items.Count - 1;

            var logGrid = new LogGrid();
            logGrid.Drop += TableView_Drop;
            logGrid.CarregarArquivo(arquivo);
            tabItem.Content = logGrid;
        }

        private void TableView_Drop(object sender, DragEventArgs e)
        {
            var arquivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            arquivos?.ForEach(CarregarArquivo);
        }

        private void MnuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Log Files|*.log",
                FileName = "*.log",
                Title = "Selecione um arquivo de log",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog(this) == true)
                openFileDialog.FileNames.ForEach(CarregarArquivo);
        }

        private void MnuFileExit_Click(object sender, RoutedEventArgs e)
            => Close();

        private void MnuToolsConfiguration_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
