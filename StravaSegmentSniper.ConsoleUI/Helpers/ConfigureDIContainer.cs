using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StravaSegmentSniper.ConsoleUI.UI;
using StravaSegmentSniper.ConsoleUI.UI.Athlete;
using StravaSegmentSniper.ConsoleUI.UI.LocalDataUI;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI;

namespace StravaSegmentSniper.ConsoleUI.Helpers
{
    public class ConfigureDIContainer
    {
        public static IHost Configure()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                  .ConfigureServices((context, services) =>
                  {
                      //register types for legacy app
                      services.AddScoped<IStravaConsoleUIMain, StravaConsoleUIMain>();
                      services.AddScoped<IApplication, Application>();
                      services.AddScoped<IViewAthleteUI, ViewAthleteUI>();
                      services.AddScoped<IGetAthleteActivityUI, GetAthleteActivityUI>();
                      services.AddScoped<IViewTrophyCaseUI, ViewTrophyCaseUI>();
                      services.AddScoped<ICheckTokenUI, CheckTokenUI>();
                      services.AddScoped<IAthleteActivityService, AthleteActivityService>();
                      services.AddScoped<IAthleteService, AthleteService>();
                      services.AddScoped<IStravaAPIService, StravaAPIService>();
                      services.AddScoped<ITokenService, TokenService>();
                      services.AddScoped<IUserService, UserService>();

                      //register types for local EF data
                      services.AddScoped<IViewLocalDataUI, ViewLocalDataUI>();
                      services.AddScoped<IViewLocalAthleteInfoUI, ViewLocalAthleteInfoUI>();
                      services.AddScoped<IViewLocalAthleteActivityUI, ViewLocalAthleteActivityUI>();
                      services.AddScoped<IDataAccessEF, DataAccessEF>();

                      services.AddAutoMapper(typeof(Program));

                      services.AddDbContext<StravaSegmentSniperDBContext>();
                  });

            return host.Build();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsetting.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
