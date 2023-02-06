namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IViewAthleteUI
    {
        void ViewAthleteMenu();
        void ViewAthleteDetailsMenu(int userId);
        void ViewAthleteDetails(int userId);
        void InvalidSelection();
    }
}