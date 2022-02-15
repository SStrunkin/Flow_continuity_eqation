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

            if (textBox.Text == "")
            {
                textBox.Foreground = Brushes.Black;
            }


            String textBoxContent = textBox.Text;

            textBoxContent = replacePointToComma(textBoxContent);

            textBox.Text = textBoxContent;
            textBox.CaretIndex = textBox.Text.Length;


            Double value = getTextBoxValue(textBox);


            if(textBox.Name.Equals(volumeFlowTextBoxLeft.Name))
            {
                PipeSection.volumeFlow = value;
                volumeFlowShowLabelLeft.Content = value;
                volumeFlowShowLabelLeft.Foreground = volumeFlowTextBoxLeft.Foreground;
            }
            else if(textBox.Name.Equals(flowSpeedTextBoxLeft.Name))
            {
                pipeSectionLeft.flowSpeed = value;
                flowSpeedShowLabelLeft.Content = value;
                flowSpeedShowLabelLeft.Foreground = flowSpeedTextBoxLeft.Foreground;
            }
            else if(textBox.Name.Equals(sqareTextBoxLeft.Name))
            {
                pipeSectionLeft.sqare = value;
                sqareShowLabelLeft.Content = value;
                sqareShowLabelLeft.Foreground = sqareTextBoxLeft.Foreground;
            }
            else if(textBox.Name.Equals(diametrTextBoxLeft.Name))
            {
                pipeSectionLeft.diameter = value;
                diametrShowLabelLeft.Content = value;
                diametrShowLabelLeft.Foreground = diametrTextBoxLeft.Foreground;
            }
            else if(textBox.Name.Equals(volumeFlowTextBoxRight.Name))
            {
                PipeSection.volumeFlow = value;
                volumeFlowShowLabelRight.Content = value;
                volumeFlowShowLabelRight.Foreground = volumeFlowTextBoxRight.Foreground;
            }
            else if(textBox.Name.Equals(flowSpeedTextBoxRight.Name))
            {
                pipeSectionRight.flowSpeed = value;
                flowSpeedShowLabelRight.Content = value;
                flowSpeedShowLabelRight.Foreground = flowSpeedTextBoxRight.Foreground;
            }
            else if(textBox.Name.Equals(sqareTextBoxRight.Name))
            {
                pipeSectionRight.sqare = value;
                sqareShowLabelRight.Content = value;
                sqareShowLabelRight.Foreground = sqareTextBoxRight.Foreground;
            }
            else if(textBox.Name.Equals(diametrTextBoxRight.Name))
            {
                pipeSectionRight.diameter = value;
                diametrShowLabelRight.Content = value;
                diametrShowLabelRight.Foreground = diametrTextBoxRight.Foreground;
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
                textBox.Foreground = Brushes.Black;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxesList)
            {
                if(textBox.Text == "")
                {
                    textBox.Foreground = Brushes.Blue;
                }
            }


                if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                !(sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "") 
                )
            {
                diametrTextBoxLeft.Text = pipeSectionLeft.calculateDiameter().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                !(diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "")
                )
            {
                sqareTextBoxLeft.Text = pipeSectionLeft.calculateSqare().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                
                
                (flowSpeedTextBoxRight.Text == "") &&
                !(sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                diametrTextBoxRight.Text = pipeSectionRight.calculateDiameter().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                
                
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                !(diametrTextBoxRight.Text == ""))
            {
                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N3");
            }

            if (!(volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                !(diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text;
                sqareTextBoxLeft.Text = pipeSectionLeft.calculateSqare().ToString("N3");

                flowSpeedTextBoxLeft.Text = pipeSectionLeft.calculatwFlowSpeed().ToString("N3");
            }

            if (!(volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                !(diametrTextBoxRight.Text == ""))
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text;

                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N3");

                flowSpeedTextBoxRight.Text = pipeSectionRight.calculatwFlowSpeed().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxLeft.Text == "") &&
                !(sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") 
                
                
                )
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text =
                    pipeSectionLeft.calculateVolumeFlow().ToString("N3");

                diametrTextBoxLeft.Text = pipeSectionLeft.calculateDiameter().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                !(diametrTextBoxLeft.Text == "") 
                 
                )
            {
                sqareTextBoxLeft.Text = pipeSectionLeft.calculateSqare().ToString("N3");

                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text =
                    pipeSectionLeft.calculateVolumeFlow().ToString("N3");
            }


            if ((volumeFlowTextBoxLeft.Text == "") &&
                
                (diametrTextBoxLeft.Text == "") &&
                
                !(flowSpeedTextBoxRight.Text == "") &&
                !(sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text =
                    pipeSectionRight.calculateVolumeFlow().ToString("N3");

                diametrTextBoxRight.Text = pipeSectionRight.calculateDiameter().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                
                (diametrTextBoxLeft.Text == "") &&
                
                !(flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                !(diametrTextBoxRight.Text == ""))
            {
                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N3");

                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text =
                    pipeSectionRight.calculateVolumeFlow().ToString("N3");
            }

            if (!(volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxLeft.Text == "") &&
                !(sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") 
                
                
                )
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text;

                diametrTextBoxLeft.Text = pipeSectionLeft.calculateDiameter().ToString("N3");

                flowSpeedTextBoxLeft.Text = pipeSectionLeft.calculatwFlowSpeed().ToString("N3");
            }

            if (
                !(volumeFlowTextBoxLeft.Text == "") &&
                (flowSpeedTextBoxRight.Text == "") &&
                !(sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text;

                diametrTextBoxRight.Text = pipeSectionRight.calculateDiameter().ToString("N3");

                flowSpeedTextBoxRight.Text = pipeSectionRight.calculatwFlowSpeed().ToString("N3");

            }

            if (!(volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") 
                )
            {
                volumeFlowTextBoxRight.Text = volumeFlowTextBoxLeft.Text;

                sqareTextBoxLeft.Text = (PipeSection.volumeFlow / pipeSectionLeft.flowSpeed).ToString("N3");

                diametrTextBoxLeft.Text = pipeSectionLeft.calculateDiameter().ToString("N3");
            }

            if (
                !(volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                volumeFlowTextBoxLeft.Text = volumeFlowTextBoxRight.Text;

                sqareTextBoxRight.Text = (PipeSection.volumeFlow / pipeSectionRight.flowSpeed).ToString("N3");

                diametrTextBoxRight.Text = pipeSectionRight.calculateDiameter().ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                !(diametrTextBoxLeft.Text == "") &&
                
                !(flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                (diametrTextBoxRight.Text == ""))
            {
                diametrTextBoxRight.Text = Math.Sqrt(pipeSectionLeft.flowSpeed * Math.Pow(pipeSectionLeft.diameter, 2) 
                    / pipeSectionRight.flowSpeed).ToString("N3");
            }

            if ((volumeFlowTextBoxLeft.Text == "") &&
                !(flowSpeedTextBoxLeft.Text == "") &&
                (sqareTextBoxLeft.Text == "") &&
                (diametrTextBoxLeft.Text == "") &&
                
                !(flowSpeedTextBoxRight.Text == "") &&
                (sqareTextBoxRight.Text == "") &&
                !(diametrTextBoxRight.Text == ""))
            {
                diametrTextBoxLeft.Text = Math.Sqrt(pipeSectionRight.flowSpeed * Math.Pow(pipeSectionRight.diameter, 2)
                    / pipeSectionLeft.flowSpeed).ToString("N3");
            }

            if (
                !(flowSpeedTextBoxLeft.Text == "") &&
                
                !(diametrTextBoxLeft.Text == "") &&
                
                (flowSpeedTextBoxRight.Text == "") &&
                
                !(diametrTextBoxRight.Text == ""))
            {                

                flowSpeedTextBoxRight.Text = (pipeSectionLeft.flowSpeed * Math.Pow(pipeSectionLeft.diameter, 2)
                    / Math.Pow(pipeSectionRight.diameter, 2)).ToString("N3");

                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N3");
            }

            if (
                !(diametrTextBoxLeft.Text == "") &&
                
                !(flowSpeedTextBoxRight.Text == "") &&
                
                !(diametrTextBoxRight.Text == ""))
            {
                flowSpeedTextBoxLeft.Text = (pipeSectionRight.flowSpeed * Math.Pow(pipeSectionRight.diameter, 2)
                    / Math.Pow(pipeSectionLeft.diameter, 2)).ToString("N3");

                sqareTextBoxRight.Text = pipeSectionRight.calculateSqare().ToString("N3");

                volumeFlowTextBoxLeft.Text = volumeFlowTextBoxRight.Text = pipeSectionRight.calculateVolumeFlow().ToString("N3");

                sqareTextBoxLeft.Text = pipeSectionLeft.calculateSqare().ToString("N3");
            }

            foreach (var textBox in textBoxesList)
            {
                if (textBox.Text == "")
                {
                    textBox.Foreground = Brushes.Black;
                }
            }

        }
    }
}
