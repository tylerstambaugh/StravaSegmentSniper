namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IViewTrophyCaseUI
    {
        void InvalidSelection();
        void ViewAllDetailedSegments(long stravaAthleteId);
        void ViewTrophyCase(long stravaAthleteId);
    }
}