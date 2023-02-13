using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.ConsoleUI.UI
{
    public interface ICheckTokenUI
    {
        void CheckTokenExpiration(Token token);
        void RefreshToken(int userId);
        void ViewTokenForAthlete(int userId);
        void ViewTokenMenu();
    }
}