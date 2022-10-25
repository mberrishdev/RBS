using Microsoft.EntityFrameworkCore;
using RBS.Domain.AdditionalInformations;
using RBS.Domain.Addresses;
using RBS.Domain.Countries;
using RBS.Domain.Images;
using RBS.Domain.languages;
using RBS.Domain.Menus;
using RBS.Domain.PlatformNotifications;
using RBS.Domain.PrivacyPolicies;
using RBS.Domain.RefreshTokens;
using RBS.Domain.ReservationReminders;
using RBS.Domain.Reservations;
using RBS.Domain.RestaurantNotifications;
using RBS.Domain.RestaurantPolicies;
using RBS.Domain.Restaurants;
using RBS.Domain.Reviews;
using RBS.Domain.SubMenuItems;
using RBS.Domain.SubMenus;
using RBS.Domain.TableImages;
using RBS.Domain.Tables;
using RBS.Domain.TermsAndConditions;
using RBS.Domain.TextContents;
using RBS.Domain.UsersAndRoles;

namespace RBS.Persistence.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<SubMenuItem> SubMenuItems { get; set; }
        public DbSet<Country> Countrise { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableImage> TableImages { get; set; }
        public DbSet<RestaurantNotification> RestaurantNotification { get; set; }
        public DbSet<PlatformNotification> PlatformNotification { get; set; }
        public DbSet<ReservationRemainder> ReservationRemainders { get; set; }
        public DbSet<Caption> Captions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TermAndCondition> TermsAndConditions { get; set; }
        public DbSet<PrivacyPolicy> PirvacyPolicies { get; set; }
        public DbSet<RestaurantPolicy> RestaurantPolicies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>().HasOne(item => item.Role).WithMany(item => item.UserRoles).HasForeignKey(item => item.RoleId);
            builder.Entity<ApplicationUserRole>().HasOne(item => item.User).WithMany(item => item.UserRoles).HasForeignKey(item => item.UserId);


            builder.Entity<ApplicationUser>().HasMany(a => a.Reservation).WithOne(r => r.ApplicationUser);
            builder.Entity<ApplicationUser>().HasMany(a => a.RestaurantNotifications).WithOne(n => n.ApplicationUser);
            builder.Entity<ApplicationUser>().HasOne(a => a.PlatformNotification).WithOne(n => n.ApplicationUser);

            builder.Entity<Restaurant>().HasOne(r => r.Address).WithOne(a => a.Restaurant).HasForeignKey<Address>(a => a.RestaurantId);
            builder.Entity<Restaurant>().HasOne(r => r.Menus).WithOne(m => m.Restaurant).HasForeignKey<Menu>(a => a.RestaurantId);

            builder.Entity<Reservation>().HasOne(r => r.Table).WithOne(t => t.Reservation);
            builder.Entity<Reservation>().HasOne(r => r.ReservationReminder).WithOne(t => t.Reservation);

            builder.Entity<Restaurant>().HasMany(r => r.AdditionalInformations).WithOne(i => i.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.Images).WithOne(i => i.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.Reviews).WithOne(r => r.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.RSTypes).WithOne(r => r.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.Reservations).WithOne(r => r.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.Tables).WithOne(t => t.Restaurant);
            builder.Entity<Restaurant>().HasMany(r => r.RestaurantPolicies).WithOne(p => p.Restaurant);

            builder.Entity<Language>().HasMany(l => l.Captions).WithOne(x => x.Language);
            builder.Entity<Language>().HasMany(l => l.TermsAndConditions).WithOne(x => x.Language);
            builder.Entity<Language>().HasMany(l => l.PrivacyPolicies).WithOne(x => x.Language);
            builder.Entity<Language>().HasMany(l => l.RestaurantPolicies).WithOne(x => x.Language);
            builder.Entity<Language>().HasOne(l => l.Country).WithOne(x => x.Language);

            builder.Entity<Restaurant>().HasMany(r => r.RestaurantNotifications).WithOne(n => n.Restaurant);

            //builder.Entity<Country>().HasMany(c => c.ApplicationUsers).WithOne(a => a.Country);

            builder.Entity<Table>().HasMany(t => t.Images).WithOne(r => r.Table);

            builder.Entity<Menu>().HasMany(m => m.SubMenus).WithOne(s => s.Menu);
            builder.Entity<SubMenu>().HasMany(s => s.Items).WithOne(i => i.SubMenu);

            builder.Entity<Review>().Property(p => p.OverallRate).HasComputedColumnSql("([FoodRate] + [ServiceRate]+[AmbienceRate])/3");
        }
    }
}
