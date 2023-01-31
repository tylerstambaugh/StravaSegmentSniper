namespace StravaSegmentSniper.Services.Internal.Models.Misc
{
    public class PhotosModel
    {
        public Primary Primary { get; set; }
        public int Count { get; set; }
    }

    public class Primary
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public UrlsModel Urls { get; set; }
        public int Source { get; set; }
    }
}
