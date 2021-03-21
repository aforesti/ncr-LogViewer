namespace LogViewer
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Detalhes.xaml
    /// </summary>
    public partial class Detalhes : Window
    {
        public Detalhes(Window owner, string info)
        {
            InitializeComponent();
            Owner = owner;
            Info.Text = info;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
            => Clipboard.SetText(Info.Text);
    }
}
