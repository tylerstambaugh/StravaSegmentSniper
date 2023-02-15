using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniper.ConsoleUI;
using StravaSegmentSniper.ConsoleUI.UI;
using StravaSegmentSniper.ConsoleUI.UI.Athlete;
using StravaSegmentSniper.ConsoleUI.UI.LocalDataUI;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Data.Entities.User;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniperReact.Data;

namespace StravaSegmentSniperReact
{
    public static class ConfigureApp
    {

        public static WebApplicationBuilder Configure(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("StravaSegmentSniperData");

            builder.Services.AddDbContext<StravaSegmentSniperDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<StravaSegmentSniperDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<AppUser, StravaSegmentSniperDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(Program));

            //builder.Services.AddDbContext<StravaSegmentSniperDbContext>();

            //register types for legacy app
            //builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());
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
        }
    }
}
