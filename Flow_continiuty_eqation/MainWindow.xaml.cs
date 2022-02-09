using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        BitmapImage littlePipe = new BitmapImage();
        BitmapImage bigPipe = new BitmapImage();
        
      
        

        public MainWindow()
        {
            InitializeComponent();


            littlePipe.BeginInit();
            littlePipe.UriSource = new Uri("/assets/little.bmp", UriKind.Relative);
            littlePipe.EndInit();
            mainImageLeft.Stretch = Stretch.Fill;

            bigPipe.BeginInit();
            bigPipe.UriSource = new Uri("/assets/big.bmp", UriKind.Relative);
            bigPipe.EndInit();
            mainImageRight.Stretch = Stretch.Fill;

            sqareTextBoxLeft.TextChanged += setMainPictures;
            sqareTextBoxRight.TextChanged += setMainPictures;


            List<TextBox> textBoxesList = new List<TextBox>();

            textBoxesList.Add(volumeFlowTextBoxLeft);
            textBoxesList.Add(flowSpeedTextBoxLeft);
            textBoxesList.Add(sqareTextBoxLeft);
            textBoxesList.Add(diametrTextBoxLeft);
            textBoxesList.Add(volumeFlowTextBoxRight);
            textBoxesList.Add(flowSpeedTextBoxRight);
            textBoxesList.Add(sqareTextBoxRight);
            textBoxesList.Add(diametrTextBoxRight);
            
            foreach(var textBox in textBoxesList)
            {              
                textBox.TextChanged += TextBox_TextChanged;
            }



                                   

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            String textBoxContent = textBox.Text;

            if (textBoxContent.Contains("."))
            {               
                textBoxContent = textBoxContent.Replace('.', ',');
            }            

            textBox.Text = textBoxContent;
            textBox.CaretIndex = textBox.Text.Length;
        }

        private void setMainPictures(object sender, TextChangedEventArgs e)
        {                        
            if ((sqareTextBoxLeft.Text != "") && (sqareTextBoxRight.Text != ""))
            {
                String leftSqareValueString = "", rightSqareValueString = "";
                Double leftSqareValueDouble = 0, rightSqareValueDouble = 0;

                leftSqareValueString = sqareTextBoxLeft.Text;
                rightSqareValueString = sqareTextBoxRight.Text;

                try
                {
                    leftSqareValueDouble = Double.Parse(leftSqareValueString);
                    rightSqareValueDouble = Double.Parse(rightSqareValueString);
                }
                catch (Exception)
                {}

                if(leftSqareValueDouble == rightSqareValueDouble)
                {
                    mainImageLeft.Source = littlePipe;
                    mainImageRight.Source = littlePipe;                   
                }
                else if(leftSqareValueDouble > rightSqareValueDouble)
                {
                    mainImageLeft.Source = bigPipe;
                    mainImageRight.Source = littlePipe;                    
                }
                else if(leftSqareValueDouble < rightSqareValueDouble)
                {
                    mainImageLeft.Source = littlePipe;
                    mainImageRight.Source = bigPipe;
                }
            }
        }

       

    }
}
