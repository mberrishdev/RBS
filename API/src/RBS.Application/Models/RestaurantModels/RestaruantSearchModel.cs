namespace RBS.Application.Models.RestaurantModels
{
    public class RestaruantSearchModel
    {
        public int Id { get; set; }
        public bool IsNew { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImgSrc { get; set; }
        public string ImgAlt { get; set; }
        public int Review { get; set; }
        public List<DateTime> FreeTime { get; set; }
    }
}
