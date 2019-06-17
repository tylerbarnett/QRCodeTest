using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace QRCodeGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();

      QRCodeData qrCodeData = qrGenerator.CreateQrCode("Site Code IS BADASS! WEBSITE IS IMCLOUD.COM", QRCoder.QRCodeGenerator.ECCLevel.Q);
      QRCode qrCode = new QRCode(qrCodeData);
      Bitmap qrCodeImage = qrCode.GetGraphic(20);
      var directory = (Path.Combine(Environment.CurrentDirectory, "../", "TempSiteDocuments"));
      if (!Directory.Exists(directory))
      {
        Directory.CreateDirectory(directory);
      }
      var filePath = Path.Combine(directory, "Test");
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        qrCodeImage.Save(stream, ImageFormat.Jpeg);
        //qrCodeImage.CopyTo(stream);
      }
    }
  }
}
