using System;
using System.Collections.Generic;
using System.Text;

namespace BarCodeExample
{  
    public class Barcodes
    {
        public enum YesNoEnum
        {
            Yes,
            No
        }

        public enum BarcodeEnum
        {
            Encoder
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        private string data;

        public BarcodeEnum BarcodeType
        {
            get { return barcodeType; }
            set { barcodeType = value; }
        }
        private BarcodeEnum barcodeType;

        public YesNoEnum CheckDigit
        {
            get { return checkDigit; }
            set { checkDigit = value;}
        }
        private YesNoEnum checkDigit;

        public string HumanText
        {
            get {
                return humanText; 
            }
            set { humanText = value; }
        }
        private string humanText;

        public string EncodedData
        {
            get { return encodedData; }
            set { encodedData = value; }
        }
        private string encodedData;

        public void encode()
        {
            int check=0;
            if (checkDigit == Barcodes.YesNoEnum.Yes)
                check = 1;

            if (barcodeType == BarcodeEnum.Encoder)
            {
                Encoder barcode = new Encoder();  //Encoder class object
                encodedData = barcode.encode(data, check);
                humanText = barcode.getHumanText();
            }
        }
    }    
}