using RBS.Application.Models.QRModels;

namespace RBS.Application.Services.QrCodeServices
{
    public interface IQrCodeService
    {
        QRModel GenerateByteArrayQrCode(string url);
    }
}
