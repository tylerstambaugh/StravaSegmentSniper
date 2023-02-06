namespace StravaSegmentSniper.ConsoleUI.UI.Athlete
{
    public interface IGetAthleteActivityUI
    {
        void GetAllSegmentEffortsByActivityId(int userId);
        void GetAthleteActivityMenu(int userId);
        void GetDetailedActivityById(int userId);
        void GetSummaryActivityForATimeRange(int userId);
        void InvalidSelection();
    }
}