using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.ConsoleUI.UI
{
    public interface ICheckTokenUI
    {
        void CheckTokenExpiration(Token token);
        void RefreshToken(string refreshToken, long stravaAthleteId);
        void ViewTokenForAthlete(long stravaAthleteId);
        void ViewTokenMenu();
    }
}