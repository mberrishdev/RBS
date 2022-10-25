using RBS.Domain.Enums;
using RBS.Domain.Images;

namespace RBS.Application.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public bool? IsMain { get; set; }
        public bool? IsTop { get; set; }
        public ImageType? ImageType { get; set; }
        public int OrderNumber { get; set; }

        public ImageModel(Image x)
        {
            Id = x.Id;
            Src = x.Src;
            Alt = x.Alt;
            IsMain = x.IsMain;
            IsTop = x.IsTop;
            ImageType = x.ImageType;
            OrderNumber = x.OrderNumber;
        }
    }
}
