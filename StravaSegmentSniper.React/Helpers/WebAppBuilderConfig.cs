using Authorization.Data.Data;
using Authorization.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniperReact.Data;

namespace StravaSegmentSniper.React.Helpers
{
    public class WebAppBuilderConfig
    {
        public static WebApplicationBuilder ConfigureBuilder()
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

            //add automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //add DI services to the container
            builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());

            // var app = builder.Build();

            return builder;
        }



    }
}
