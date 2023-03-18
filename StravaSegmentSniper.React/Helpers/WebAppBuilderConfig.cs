using Authorization.Data.Data;
using Authorization.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace StravaSegmentSniper.React.Helpers
{
    public class WebAppBuilderConfig
    {
        public static WebApplicationBuilder Builder()
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            var authConnectionString = builder.Configuration.GetConnectionString("AuthorizationData");
            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(authConnectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AuthDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<WebAppUser, AuthDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            var appDataConnectionString = builder.Configuration.GetConnectionString("StravaSegmentSniperData");
            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(appDataConnectionString));

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // var app = builder.Build();

            return builder;
        }



    }
}
