using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StravaSegmentSniper.ConsoleUI.UI;
using StravaSegmentSniper.ConsoleUI.UI.Athlete;
using StravaSegmentSniper.ConsoleUI.UI.LocalDataUI;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.ConsoleUI.Helpers
{
    public class ConfigureHost
    {
        public static IHost Configure()
        {
            //var builder = new ConfigurationBuilder();
            //BuildConfig(builder);

            var host = Host.CreateDefaultBuilder();

            host.ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsetting.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
            });

            host.ConfigureServices((context, services) =>
                  {
                      services.AddAutoMapper(typeof(Program));

                      services.AddDbContext<StravaSegmentSniperDbContext>(
                        options => options.UseLazyLoadingProxies());

                      //register types for legacy app
                      //services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());
                      services.AddScoped<IStravaConsoleUIMain, StravaConsoleUIMain>();
                      services.AddScoped<IApplication, Application>();
                      services.AddScoped<IAthleteActivityService, AthleteActivityService>();
                      services.AddScoped<IAthleteService, AthleteService>();
                      services.AddScoped<ITokenService, TokenService>();


                      //services that call Strava
                      services.AddScoped<IStravaAPIAthlete, StravaAPIAthlete>();
                      services.AddScoped<IStravaAPIActivity, StravaAPIActivity>();
                      services.AddScoped<IStravaAPISegment, StravaAPISegment>();
                      services.AddScoped<IStravaAPIToken, StravaAPIToken>();
                      //register types for local console views
                      services.AddScoped<IViewLocalDataUI, ViewLocalDataUI>();
                  });

            return host.Build();
        }
    }
}
