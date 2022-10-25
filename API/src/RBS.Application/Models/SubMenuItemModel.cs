using RBS.Domain.SubMenuItems;

namespace RBS.Application.Models
{
    public class SubMenuItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Allergy { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string CurrencyIcon { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public SubMenuItemModel(SubMenuItem subMenuItem)
        {
            Id = subMenuItem.Id;
            Name = subMenuItem.Name;
            Description = subMenuItem.Description;
            Allergy = subMenuItem.Allergy;
            Price = subMenuItem.Price;
            Currency = subMenuItem.Currency;
            CurrencyIcon = subMenuItem.CurrencyIcon;
            Src = subMenuItem.Src;
            Alt = subMenuItem.Alt;
        }
    }
}
