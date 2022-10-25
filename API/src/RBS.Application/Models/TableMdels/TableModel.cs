using RBS.Domain.Tables;

namespace RBS.Application.Models.TableMdels
{
    public class TableModel
    {
        public int PersonCount { get; set; }
        public int RestaurantId { get; set; }

        public TableModel(Table table)
        {
            PersonCount = table.PersonCount;
            RestaurantId = table.RestaurantId;
        }
    }
}
