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
using System.Windows.Shapes;

namespace BarCodeExample
{
    /// <summary>
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : Window
    {
        //Default Contructor
        public Barcode()
        {
            InitializeComponent();

            //Creating Barcode with a dummy product code. Note: You can customize accordint to your needs.
            string productCode = "ABC1234890";
            CreateBarCode(productCode);
        }

        //Encode Data to create Barcode
        private void CreateBarCode(string productCode)
        {
            ////////////////////////////////////////////
            // Encode The Code with the help of Encoder 
            ///////////////////////////////////////////
            Barcodes barCode = new Barcodes();
            barCode.BarcodeType = Barcodes.BarcodeEnum.Encoder;
            barCode.Data = productCode;
            barCode.CheckDigit = Barcodes.YesNoEnum.Yes;
            barCode.encode();

            //Dimensions of the Bars, you can use according to your need
            int thinWidth;
            int thickWidth;
            thinWidth = 3;
            thickWidth = 3 * thinWidth;

            string encodedText = barCode.EncodedData; //Encoded product code
            string humanText = barCode.HumanText; //Human readable product code

            /////////////////////////////////////
            // Draw The Barcode
            /////////////////////////////////////
            int length = encodedText.Length;
            int currentPos = 10;
            int currentTop = 10;
            int currentColor = 0;

            for (int i = 0; i < length; i++){

                Rectangle rectangle = new Rectangle(); //Create a rectangle which will form as Barcode
                rectangle.Height = 200;

                if (currentColor == 0){
                    currentColor = 1;
                    rectangle.Fill = new SolidColorBrush(Colors.Black);
                }
                else{
                    currentColor = 0;
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                }

                Canvas.SetLeft(rectangle, currentPos);
                Canvas.SetTop(rectangle, currentTop);

                if (encodedText[i] == 't'){
                    rectangle.Width = thinWidth;
                    currentPos += thinWidth;
                }
                else if (encodedText[i] == 'w'){
                    rectangle.Width = thickWidth;
                    currentPos += thickWidth;
                }

                //Bind Barcode to XAML Canvas 
                mainCanvas.Children.Add(rectangle);  
            }


            ////////////////////////////////////////////////
            // Add the Human Readable Text and its alignment
            ///////////////////////////////////////////////
            TextBlock block = new TextBlock(); //WPF Text Block
            block.Text = humanText; //Set human readable product code
            block.FontSize = 32;
            block.FontFamily = new FontFamily("Courier New");
            Rect rect = new Rect(0, 0, 0, 0);
            block.Arrange(rect);
            Canvas.SetLeft(block, (currentPos - block.ActualWidth) / 2);
            Canvas.SetTop(block, currentTop + 205);
            mainCanvas.Children.Add(block);
        }
    }
}
