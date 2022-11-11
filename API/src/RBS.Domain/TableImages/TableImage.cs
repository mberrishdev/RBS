namespace RBS.Domain.TableImages
{
    public class TableImage : EntityBase
    {
        public string? Src { get; private set; }
        public string? Alt { get; private set; }
        public bool Is360 { get; private set; }

        public int TableId { get; private set; }
        public Table Table { get; private set; }
    }
}
