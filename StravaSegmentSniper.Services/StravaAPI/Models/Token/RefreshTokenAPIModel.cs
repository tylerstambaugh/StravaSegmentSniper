namespace StravaSegmentSniper.Services.StravaAPI.Models.Token
{
    public class RefreshTokenAPIModel
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public long expires_at { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}