namespace StravaSegmentSniper.ConsoleUI.UI.LocalDataUI
{
    public interface IViewLocalAthleteInfoUI
    {
        void InvalidSelection();
        void ViewAthleteDetailsMenu(long stravaAthleteId);
        void ViewLocalAthleteMenu();
    }
}