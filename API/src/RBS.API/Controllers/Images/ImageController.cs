using Microsoft.AspNetCore.Mvc;
using QRCoder;
using RBS.Application.Models;
using RBS.Application.Services.Images;
using RBS.Application.Services.Menus;
using System.Drawing;

namespace RBS.API.Controllers.Images
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ImageController : ApiControllerBase
    {

        private readonly IImageService _imageService;
        private readonly IMenuService _menuService;

        public ImageController(IImageService imageService, IMenuService menuService)
        {
            _imageService = imageService;
            _menuService = menuService;
        }

        [HttpGet("GetRestaurantImages/{id}/{typeId}")]
        [ProducesResponseType(typeof(List<ImageModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ImageModel>>> GetRestaurantImages([FromRoute] int id, [FromRoute] int typeId)
        {
            var result = await _imageService.GetRestaurantImages(id, typeId);
            return Ok(result);
        }

        [HttpGet("GetRestaurantTopImage/{restaurantId}")]
        [ProducesResponseType(typeof(ImageModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ImageModel>> GetRestaurantTopImage([FromRoute] int restaurantId)
        {

            var url = "https://medium.com/@marcosvinicios_net";

            var image = QrCodeGenerator.GenerateByteArray(url);
            return File(image, "image/jpeg");

            //var result = await _imageService.GetRestaurantTopImage(restaurantId);
            //return Ok(result);
        }
    }

    public static class QrCodeGenerator
    {
        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }

        public static Bitmap GenerateImage(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
