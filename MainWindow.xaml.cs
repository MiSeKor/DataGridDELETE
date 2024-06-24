using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridDELETE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM VM = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new();
            w1.Show();
        }

        private void DataGrid1_OnBeginningEdit(object? sender, DataGridBeginningEditEventArgs e)
        {
            if (VM.SelectedData.IsChecked) e.Cancel = true;
        }
    }
}