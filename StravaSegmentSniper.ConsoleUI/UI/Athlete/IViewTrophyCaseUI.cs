namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IViewTrophyCaseUI
    {
        void InvalidSelection();
        void ViewAllDetailedSegments(int userId);
        void ViewTrophyCase(int userId);
    }
}