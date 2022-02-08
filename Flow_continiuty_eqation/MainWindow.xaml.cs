using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flow_continiuty_eqation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PipeSection pipeSectionLeft = new PipeSection();
        PipeSection pipeSectionRight = new PipeSection();

       

        public MainWindow()
        {
            InitializeComponent();

            sqareTextBoxLeft.Text = "0";
            sqareTextBoxRight.Text = "0";

            
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("/assets/little.bmp", UriKind.Relative);
            bi3.EndInit();
            mainImageLeft.Stretch = Stretch.Fill;
            mainImageLeft.Source = bi3;

            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri("/assets/big.bmp", UriKind.Relative);
            bi4.EndInit();
            mainImageRight.Stretch = Stretch.Fill;
            mainImageRight.Source = bi4;
        }


        private void setMainPictures()
        {

        }
        
    }
}
