using RBS.Domain.Tables;

namespace RBS.Application.Models.TableMdels
{
    public class TableModel
    {
        public int Id { get; set; }
        public decimal XCoordinate { get; set; }
        public decimal YCoordinate { get; set; }
        public int PersonCount { get; set; }
        public int RestaurantId { get; set; }
        public string Status { get; set; }

        public TableModel(Table table)
        {
            Id = table.Id;
            PersonCount = table.PersonCount;
            RestaurantId = table.RestaurantId;
            XCoordinate = table.XCoordinage;
            YCoordinate = table.YCoordinage;
            Status = "free";
        }
    }
}
