namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IGetAthleteActivityUI
    {
        void GetAllSegmentEffortsByActivityId(long stravaAthleteId);
        void GetAthleteActivityMenu(long stravaAthleteId);
        void GetDetailedActivityById(long stravaAthleteId);
        void GetSummaryActivityForATimeRange(long stravaAthleteId);
        void InvalidSelection();
    }
}