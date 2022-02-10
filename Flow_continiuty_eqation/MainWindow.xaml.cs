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

        List<TextBox> textBoxesList = new List<TextBox>();


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

            mainImageLeft.Source = littlePipe;
            mainImageRight.Source = littlePipe;


            

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
                textBox.MouseDoubleClick += TextBox_MouseDoubleClick;
            }
            

        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            String textBoxContent = textBox.Text;

            textBoxContent = replacePointToComma(textBoxContent);

            textBox.Text = textBoxContent;
            textBox.CaretIndex = textBox.Text.Length;


            Double value = getTextBoxValue(textBox);


            if(textBox.Name.Equals(volumeFlowTextBoxLeft.Name))
            {
                PipeSection.volumeFlow = value;
            }
            else if(textBox.Name.Equals(flowSpeedTextBoxLeft.Name))
            {
                pipeSectionLeft.flowSpeed = value;
            }
            else if(textBox.Name.Equals(sqareTextBoxLeft.Name))
            {
                pipeSectionLeft.sqare = value;
            }
            else if(textBox.Name.Equals(diametrTextBoxLeft.Name))
            {
                pipeSectionLeft.diameter = value;
            }
            else if(textBox.Name.Equals(volumeFlowTextBoxRight.Name))
            {
                PipeSection.volumeFlow = value;
            }
            else if(textBox.Name.Equals(flowSpeedTextBoxRight.Name))
            {
                pipeSectionRight.flowSpeed = value;
            }
            else if(textBox.Name.Equals(sqareTextBoxRight.Name))
            {
                pipeSectionRight.sqare = value;
            }
            else if(textBox.Name.Equals(diametrTextBoxRight.Name))
            {
                pipeSectionRight.diameter = value;
            }


            setMainPictures();

        }

        private Double getTextBoxValue(TextBox textBox)
        {
            Double doubleValue = 0;

            try
            {

                doubleValue = Double.Parse(textBox.Text);
                textBox.Background = Brushes.White;

            }
            catch (Exception)
            {

                textBox.Background = Brushes.PaleVioletRed;

                if (textBox.Text == "")
                {
                    textBox.Background = Brushes.White;
                }
            }

            return doubleValue;
        }

        private String replacePointToComma(String textBoxContent)
        {            
            if (textBoxContent.Contains("."))
            {
                textBoxContent = textBoxContent.Replace('.', ',');
            }

            return textBoxContent;
        }

        private void setMainPictures()
        {                                   
                if(pipeSectionLeft.sqare == pipeSectionRight.sqare)
                {
                    mainImageLeft.Source = littlePipe;
                    mainImageRight.Source = littlePipe;                   
                }
                else if(pipeSectionLeft.sqare > pipeSectionRight.sqare)
                {
                    mainImageLeft.Source = bigPipe;
                    mainImageRight.Source = littlePipe;                    
                }
                else if(pipeSectionLeft.sqare < pipeSectionRight.sqare)
                {
                    mainImageLeft.Source = littlePipe;
                    mainImageRight.Source = bigPipe;
                }            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxesList)
            {
                textBox.Clear();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                !(sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                (volumeFlowTextBoxRight.Text == "") &&
                (flowSpeedTextBoxRight.Text == "") 
                )
            {
                diametrTextBoxLeft.Text = pipeSectionLeft.calculateDiameter().ToString("N2");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                (volumeFlowTextBoxRight.Text == "") &&
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                !(diametrTextBoxLeft.Text == "") &&
                (volumeFlowTextBoxRight.Text == "") &&
                (flowSpeedTextBoxRight.Text == "")
                )
            {
                sqareTextBoxLeft.Text = pipeSectionLeft.calculateSqare().ToString("N2");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                
                (volumeFlowTextBoxRight.Text == "") &&
                (flowSpeedTextBoxRight.Text == "") &&
                !(sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                diametrTextBoxRight.Text = pipeSectionRight.calculateDiameter().ToString("N2");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                
                (volumeFlowTextBoxRight.Text == "") &&
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                !(diametrTextBoxRight.Text == ""))
            {
                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N2");
            }
        }
    }
}
