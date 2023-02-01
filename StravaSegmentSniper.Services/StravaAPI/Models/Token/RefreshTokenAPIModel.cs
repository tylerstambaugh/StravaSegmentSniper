namespace StravaSegmentSniper.Services.StravaAPI.Models.Token
{
    public class RefreshTokenAPIModel
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresAt { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}