namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IViewAthleteUI
    {
        void InvalidSelection();
        void ViewAthleteDetails(int userId);
        void ViewAthleteDetailsMenu(int userId);
        void ViewAthleteMenu();
    }
}