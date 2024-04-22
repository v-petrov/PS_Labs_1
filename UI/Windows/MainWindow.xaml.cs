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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideListVisibility_Click(object sender, RoutedEventArgs e)
        {
            studentsList.Visibility = studentsList.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            this.Background = GetRandomColorBrush();
        }

        private void ChangeBorderColor_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush newColor = GetRandomColorBrush();
            LeftBorder.Background = newColor;
            RightBorder.Background = newColor;
            TopBorder.Background = newColor;
            BottomBorder.Background = newColor;
        }

        private SolidColorBrush GetRandomColorBrush()
        {
            Random rnd = new Random();
            byte[] colorBytes = new byte[3];
            rnd.NextBytes(colorBytes);
            Color randomColor = Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);
            return new SolidColorBrush(randomColor);
        }
    }
}