namespace StravaSegmentSniper.Services.Internal.Models.Token
{
    public class StravaApiTokenModel
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public long ExpiresAt { get; set; }
        public long ExpiresIn { get; set; }
    }
}
