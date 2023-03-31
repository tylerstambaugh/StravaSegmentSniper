using Authorization.Data.Data;
using Authorization.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.React.Helpers
{
    public class WebAppBuilderConfig
    {
        public static WebApplicationBuilder ConfigureBuilder()
        {
            var builder = WebApplication.CreateBuilder();


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
            builder.Services.AddDbContext<StravaSegmentSniperDbContext>(options =>
                options.UseSqlServer(appDataConnectionString).UseLazyLoadingProxies());

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //add automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());

            //add DI services to the container
            builder.Services.AddScoped<IAthleteActivityService, AthleteActivityService>();
            builder.Services.AddScoped<IAthleteService, AthleteService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWebAppUserService, WebAppUserService>();
            builder.Services.AddScoped<IStravaAPIAthlete, StravaAPIAthlete>();
            builder.Services.AddScoped<IStravaAPIActivity, StravaAPIActivity>();
            builder.Services.AddScoped<IStravaAPISegment, StravaAPISegment>();
            builder.Services.AddScoped<IStravaAPIToken, StravaAPIToken>();

            //register types for local EF data



            return builder;
        }



    }
}
