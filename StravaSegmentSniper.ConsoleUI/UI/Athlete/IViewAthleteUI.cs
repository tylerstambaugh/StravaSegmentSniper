namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IViewAthleteUI
    {
        void ViewAthleteMenu();
        void ViewAthleteDetailsMenu(long stravaAthleteId);
        void ViewAthleteDetails(int userId);
        void InvalidSelection();
    }
}