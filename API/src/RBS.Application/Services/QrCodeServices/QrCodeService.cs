using QRCoder;
using RBS.Application.Models.QRModels;
using System.Drawing;

namespace RBS.Application.Services.QrCodeServices
{
    public class QrCodeService : IQrCodeService
    {
        public QRModel GenerateByteArrayQrCode(string url)
        {
            var image = GenerateImage(url);
            var bytes = ImageToByte(image);
            return new()
            {
                Data = bytes,
                QrImage = "data:image/png," + bytes.ToString(),
                FileName = "ReservationQrCode"
            };
        }

        private Bitmap GenerateImage(string url)
        {
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }

        private byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
