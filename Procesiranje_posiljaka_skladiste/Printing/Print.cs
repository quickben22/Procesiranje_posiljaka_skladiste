using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Procesiranje_posiljaka_skladiste.Printing
{
    class Print
    {
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;

        public void start()
        {
            if (!ConnectPrinter())
                return;

            //int multiplier = 1;
            // 203 DPI : 1mm is about 8 dots
            // 300 DPI : 1mm is about 12 dots
            // 600 DPI : 1mm is about 24 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            //if (resolution >= 600)
            //    multiplier = 3;

            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            BXLLApi.PrintTrueFont(20 * dotsPer1mm, 4 * dotsPer1mm, "Arial", 28, 0, true, true, false, "OS2", false);

            BXLLApi.PrintTrueFont(10 * dotsPer1mm, 13 * dotsPer1mm, "Arial", 24, 0, true, true, false, "31400 ĐAKOVO", false);

            BXLLApi.PrintTrueFont(53 * dotsPer1mm, 11 * dotsPer1mm, "Arial", 50, 0, true, true, false, "E", false);

            BXLLApi.PrintTrueFont(12 * dotsPer1mm, 21 * dotsPer1mm, "Arial", 20, 0, true, true, false, "EM298464312HR", false);

            BXLLApi.PrintTrueFont(8 * dotsPer1mm, 28 * dotsPer1mm, "Arial", 16, 0, true, true, false, "0.946 kn   21000   17.03.2015.   10:27:50", false);


            //	Draw Lines
            //BXLLApi.PrintBlock(1 * dotsPer1mm, 10 * dotsPer1mm, 71 * dotsPer1mm, 11 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);

            //Print string using Vector Font
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font selection
            //        U: ASCII (1Byte code)
            //        K: KS5601 (2Byte code)
            //        B: BIG5 (2Byte code)
            //        G: GB2312 (2Byte code)
            //        J: Shift-JIS (2Byte code)
            // P4  : Font width (W)[dot]
            // P5  : Font height (H)[dot]
            // P6  : Right-side character spacing [dot], Plus (+)/Minus (-) option can be used. Ex) 5, +3, -10	
            // P7  : Bold
            // P8  : Reverse printing
            // P9  : Text style  (N : Normal, I : Italic)
            // P10 : Rotation (0 ~ 3)
            // P11 : Text Alignment
            //        L: Left
            //        R: Right
            //        C: Center
            // P12 : Text string write direction (0 : left to right, 1 : right to left)
            // P13 : data to print
            // ※ : Third parameter, 'ASCII' must be set if Bixolon printer is SLP-T400, SLP-T403, SRP-770 and SRP-770II.
            //PrintVectorFont(22, 65, 'U', 34, 34, "0", false, false, false, ROTATE_0, LEFTALIGN, LEFTTORIGHT, "Sample Label-2");

            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 12 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Šalji u:");
            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 17 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_19X30, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "KRK");
            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 21 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "51500 KRK");
            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 24 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Dario Vincetic");
            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 27 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Trg Bana Jelačića");
            //BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 30 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_16X25, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "916, Hrvatska");

            //BXLLApi.PrintDeviceFont(3 * dotsPer1mm, 36 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "POSTAL CODE");
            //BXLLApi.Print1DBarcode(3 * dotsPer1mm, 15 * dotsPer1mm, (int)SLCS_BARCODE.CODE39, 3 * multiplier, 5 * multiplier, 48 * multiplier, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, "1234");

            //BXLLApi.PrintDeviceFont(3 * dotsPer1mm, 50 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "AWB:");
            //BXLLApi.Print1DBarcode(3 * dotsPer1mm, 53 * dotsPer1mm, (int)SLCS_BARCODE.CODE93, 4 * multiplier, 8 * multiplier, 90 * multiplier, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, "8741493121");

            //BXLLApi.PrintDeviceFont(4 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "WEIGHT:");
            //BXLLApi.PrintDeviceFont(29 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "DELIVERY NO:");
            //BXLLApi.PrintDeviceFont(53 * dotsPer1mm, 69 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_12X20, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "DESTINATION");

            //BXLLApi.PrintDeviceFont(3 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "30Kg");
            //BXLLApi.PrintDeviceFont(26 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "425518");
            //BXLLApi.PrintDeviceFont(55 * dotsPer1mm, 73 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_32X50, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, true, "ICN");

            // Prints a DATAMATRIX
            //int xString = (35 * dotsPer1mm);
            //int yString = (83 * dotsPer1mm);
            //string DataMatrix_data = "BIXOLON Label Printer, This is for test.";
            //BXLLApi.PrintDataMatrix(xString, yString, (int)SLCS_DATAMATRIX_SIZE.DATAMATRIX_SIZE_4, false, (int)SLCS_ROTATION.ROTATE_0, DataMatrix_data);

            // Prints a QRCode
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : MODEL selection (1, 2)
            //  P4 : ECC Level (1 ~ 4)
            //  P5 : Size of QRCode (1 ~ 9)
            //  P6 : Rotation (0 ~ 3)
            //  P7 : data to print
            //string QRCode_data = "QRCode sample test 123";
            //BXLLApi.PrintQRCode(2 * dotsPer1mm, 5 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_1, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_M, (int)SLCS_QRCODE_SIZE.QRSIZE_4, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

            // Prints a PDF417
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Maximum Row Count : 3 ~ 90
            //  P4 : Maximum Column Count : 1 ~ 90
            //  P5 : Error Correction Level
            //  P6 : Data compression method
            //  P7 : HRI
            //  P8 : Barcode Origin Point
            //  P9 : Module Width : 2 ~ 9
            //  P10 : Module Height : 4 ~ 99
            //  P11 : Rotation (0 ~ 3)
            //  P12 : data to print
            //xString = (1 * dotsPer1mm);
            //yString = (114 * dotsPer1mm);
            //string PDF417_data = "BIXOLON Label Printer, This is for test.";
            //BXLLApi.PrintPDF417(xString, yString, 8, 8, 0, 0, false, 1, 3 * multiplier, 14 * multiplier, (int)SLCS_ROTATION.ROTATE_0, PDF417_data);

            // Draw BOX (Fill color is black)
            //BXLLApi.PrintBlock(1 * dotsPer1mm, 80 * dotsPer1mm, 71 * dotsPer1mm, 112 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.BOX, 4);
            //BXLLApi.PrintCircle(10, 1055, 3, 2);

            // Print Image
            //BXLLApi.PrintImageLib(1 * dotsPer1mm, 122 * dotsPer1mm, "BIXOLON.bmp", (int)SLCS_DITHER_OPTION.DITHER_1, false);

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }

        private bool ConnectPrinter()
        {
            string strPort = "";
            int nInterface = ISerial;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;

            //if (rdoIF_Serial.Checked)
            //{
            //    // SERIAL (COM)
            //    nInterface = ISerial;
            //    strPort = cmbSerial_Port.Text;
            //    nBaudrate = Convert.ToInt32(cmbSerial_Baudrate.Text);
            //    nDatabits = Convert.ToInt32(cmbSerial_Databits.Text);
            //    nParity = cmbSerial_Parity.SelectedIndex;
            //    nStopbits = cmbSerial_Stopbits.SelectedIndex;
            //}
            //else if (rdoIF_Bluetooth.Checked)
            //{
            //    // BLUETOOTH (COM)
            //    nInterface = IBluetooth;
            //    strPort = cmbSerial_Port.Text;
            //}
            //else if (rdoIF_Parallel.Checked)
            //{
            //    // PARALLEL (LPT)
            //    nInterface = IParallel;
            //    strPort = cmbLPT_Port.Text;
            //}
            //else if (rdoIF_Usb.Checked)
            //{
            // USB
            nInterface = IUsb;
            //}
            //else if (rdoIF_Lan.Checked)
            //{
            //    // NETWORK
            //    nInterface = ILan;
            //    strPort = txtNet_IPAddr.Text;
            //    nBaudrate = Convert.ToInt32(txtNet_PortNum.Text);
            //}

            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }


        private void SendPrinterSettingCommand()
        {
            // 203 DPI : 1mm is about 8 dots
            // 300 DPI : 1mm is about 12 dots
            // 600 DPI : 1mm is about 24 dots
            double txtP_Width = 70;
            double txtP_Height = 35;
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int txtMargin_X = 1;
            int txtMargin_Y = 1;
            int cmbDensity = 14;
            bool rdoTop2Bottom = true;
            int nPaper_Width = Convert.ToInt32((txtP_Width) * dotsPer1mm);
            int nPaper_Height = Convert.ToInt32((txtP_Height) * dotsPer1mm);
            int nMarginX = Convert.ToInt32((txtMargin_X) * dotsPer1mm);
            int nMarginY = Convert.ToInt32((txtMargin_Y) * dotsPer1mm);
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = Convert.ToInt32(cmbDensity);
            int nOrientation = rdoTop2Bottom ? (int)SLCS_ORIENTATION.TOP2BOTTOM : (int)SLCS_ORIENTATION.BOTTOM2TOP;

            int nSensorType = (int)SLCS_MEDIA_TYPE.GAP;
            bool rdoBmark = false;
            bool rdoContinuous = false;
            bool rdoRewind = false;
            if (rdoBmark) nSensorType = (int)SLCS_MEDIA_TYPE.BLACKMARK;
            else if (rdoContinuous) nSensorType = (int)SLCS_MEDIA_TYPE.CONTINUOUS;

            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            if (rdoRewind)
            {
                BXLLApi.PrintDirect("RWDy", true);
            }

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            bool rdoCut = false;
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, rdoCut, 1, true);

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_USA, (int)SLCS_CODEPAGE.FCP_CP1252);

            /* 
               1 Inch : 25.4mm
               1 mm   :  8 Dots (XT5-40, TX400, DX420, DX220, DL410, T400, D420, D220, SRP-770/770II/770III)
               1 mm   : 12 Dots (XT5-43, TX403, DX423, DX223, DL413, T403, D423, D223)
               1 mm   : 24 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
            bool rdoDt = true;
            if (rdoDt)
                BXLLApi.PrintDirect("STd", true);
            else // Thermal transfer
                BXLLApi.PrintDirect("STt", true);
        }

        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR: errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER: errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN: errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM: errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT: errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING: errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON: errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT: errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME: errMsg = "Unknown (or Not supported) printer name"; break;
                default: errMsg = "Unknown error"; break;
            }
            return errMsg;
        }


    }
}
