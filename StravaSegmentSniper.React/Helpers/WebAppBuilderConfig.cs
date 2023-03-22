using Authorization.Data.Data;
using Authorization.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniper.Data.DataAccess.Athlete;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniperReact.Data;
using StravaSegmentSniper.ConsoleUI.UI;

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
                options.UseSqlServer(appDataConnectionString).UseLazyLoadingProxies());

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //add automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //add DI services to the container

            var connectionString = builder.Configuration.GetConnectionString("StravaSegmentSniperData");
            builder.Services.AddDbContext<StravaSegmentSniperDbContext>();

            //builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());

            builder.Services.AddScoped<IAthleteActivityService, AthleteActivityService>();
            builder.Services.AddScoped<IAthleteService, AthleteService>();
            builder.Services.AddScoped<IStravaAPIService, StravaAPIService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWebAppUserService, WebAppUserService>();

            //register types for local EF data
            builder.Services.AddScoped<IDataAccessEF, DataAccessEF>();
            builder.Services.AddScoped<IAthleteData, AthleteData>();

            // var app = builder.Build();

            return builder;
        }



    }
}
