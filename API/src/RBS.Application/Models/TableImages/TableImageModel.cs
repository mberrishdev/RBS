using RBS.Domain.TableImages;

namespace RBS.Application.Models.TableImages
{
    public class TableImageModel
    {
        public int Id { get; set; }
        public string? Src { get; set; }
        public string? Alt { get; set; }
        public int TableId { get; set; }

        public TableImageModel(TableImage tableImage)
        {
            Id = tableImage.Id;
            Src = tableImage.Src;
            Alt = tableImage.Alt;
            TableId = tableImage.TableId;
        }
    }
}
