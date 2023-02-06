using Microsoft.Extensions.DependencyInjection;
using StravaSegmentSniper.ConsoleUI.Helpers;

namespace StravaSegmentSniper.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var host = ConfigureHost.Configure();

            var svc = ActivatorUtilities.CreateInstance<Application>(host.Services);

            svc.Run();

        }
    }
}
