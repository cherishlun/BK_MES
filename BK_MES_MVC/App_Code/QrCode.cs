using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace BK_MES_MVC.App_Code
{
    public class QrCode
    {
        public static byte[] Create_QrCode(string cFname)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",//编码
                Width = 100,
                Height = 100,
                Margin = 0,//二维码边框宽度，这里文档说设置0-4
                ErrorCorrection = ErrorCorrectionLevel.H,//容错率 

            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            Image img = writer.Write(cFname);

            ImageConverter imgconv = new ImageConverter();
            byte[] byteImage = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return byteImage;
        }

    }
}