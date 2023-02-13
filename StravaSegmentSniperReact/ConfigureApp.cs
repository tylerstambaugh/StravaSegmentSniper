using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StravaSegmentSniper.ConsoleUI;
using StravaSegmentSniper.ConsoleUI.UI;
using StravaSegmentSniper.ConsoleUI.UI.Athlete;
using StravaSegmentSniper.ConsoleUI.UI.LocalDataUI;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniperReact.Data;
using StravaSegmentSniperReact.Models;
using AutoMapper;

namespace StravaSegmentSniperReact
{
    public static class ConfigureApp
    {

        public static WebApplicationBuilder Configure(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<StravaSegmentSniperDBContext>();

            //register types for legacy app
            builder.Services.AddScoped<IStravaSegmentSniperDBContext>(provider => provider.GetService<StravaSegmentSniperDBContext>());
            builder.Services.AddScoped<IStravaConsoleUIMain, StravaConsoleUIMain>();
            builder.Services.AddScoped<IApplication, Application>();
            builder.Services.AddScoped<IViewAthleteUI, ViewAthleteUI>();
            builder.Services.AddScoped<IGetAthleteActivityUI, GetAthleteActivityUI>();
            builder.Services.AddScoped<IViewTrophyCaseUI, ViewTrophyCaseUI>();
            builder.Services.AddScoped<ICheckTokenUI, CheckTokenUI>();
            builder.Services.AddScoped<IAthleteActivityService, AthleteActivityService>();
            builder.Services.AddScoped<IAthleteService, AthleteService>();
            builder.Services.AddScoped<IStravaAPIService, StravaAPIService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();

            //register types for local EF data
            builder.Services.AddScoped<IViewLocalDataUI, ViewLocalDataUI>();
            builder.Services.AddScoped<IViewLocalAthleteInfoUI, ViewLocalAthleteInfoUI>();
            builder.Services.AddScoped<IViewLocalAthleteActivityUI, ViewLocalAthleteActivityUI>();
            builder.Services.AddScoped<IDataAccessEF, DataAccessEF>();
            return builder;

            //host.ConfigureHostConfiguration(configHost =>
            //{
            //    configHost.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsetting.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            //    .AddEnvironmentVariables();
            //});
        }
    }
}
