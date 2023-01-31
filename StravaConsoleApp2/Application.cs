using StravaSegmentSniper.ConsoleUI.UI;

namespace StravaSegmentSniper.ConsoleUI
{
    public class Application : IApplication
    {
        private readonly IStravaConsoleUIMain _stravaConsoleUIMain;

        public Application(IStravaConsoleUIMain stravaConsoleUIMain)
        {
            _stravaConsoleUIMain = stravaConsoleUIMain;
        }

        public void Run()
        {
            _stravaConsoleUIMain.Run();
        }
    }
}
