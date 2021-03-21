namespace LogViewer
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs e)
        {
            var mw = new MainWindow();
            var args = Environment.GetCommandLineArgs();
            if (args.GetLength(0) > 1 && args[1].EndsWith(".log"))
                mw.CarregarArquivo(args[1]);

            mw.Show();
        }
    }
}
