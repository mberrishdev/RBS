using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RBS.Application.Services.AdditionalInformations;
using RBS.Application.Services.Auth;
using RBS.Application.Services.Auth.Helper;
using RBS.Application.Services.Auth.TokenService;
using RBS.Application.Services.Captions;
using RBS.Application.Services.HashService;
using RBS.Application.Services.Images;
using RBS.Application.Services.Languages;
using RBS.Application.Services.Menus;
using RBS.Application.Services.PDFService;
using RBS.Application.Services.PlatformNotifications;
using RBS.Application.Services.PrivacyPolicies;
using RBS.Application.Services.QrCodeServices;
using RBS.Application.Services.ReservationRemainders;
using RBS.Application.Services.Reservations;
using RBS.Application.Services.RestaurantNotifications;
using RBS.Application.Services.Restaurants;
using RBS.Application.Services.Reviews;
using RBS.Application.Services.Settings.AuthSettings;
using RBS.Application.Services.Tables;
using RBS.Application.Services.TermsAndConditions;
using RBS.Application.Services.UserServices;
using System.Text;

namespace RBS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthSettings>(configuration.GetSection(nameof(AuthSettings)));
            services.AddSingleton<IAuthSettings>(s => s.GetRequiredService<IOptions<AuthSettings>>().Value);

            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:SecretKey"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["AuthSettings:ValidIssuer"],
                ValidAudience = configuration["AuthSettings:ValidAudience"],
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddScoped<IPrivacyPolicyService, PrivacyPolicyService>();
            services.AddScoped<ITermAndConditionService, TermAndConditionService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<ICaptionService, CaptionService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddScoped<IReservationRemainderService, ReservationRemainderService>();
            services.AddScoped<IRestaurantNotificationService, RestaurantNotificationService>();
            services.AddScoped<IPlatformNotificationService, PlatformNotificationService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IAdditionalInformationService, AdditionalInformationService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
