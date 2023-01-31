namespace StravaSegmentSniper.Services.Internal.Models.Token
{
    public class RefreshTokenModel
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresAt { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
