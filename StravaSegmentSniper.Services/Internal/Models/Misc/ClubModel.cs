namespace StravaSegmentSniper.Services.Internal.Models.Misc
{
    public class ClubModel
    {
        public int Id { get; set; }
        public int ResourceState { get; set; }
        public string Name { get; set; }
        public string ProfileMedium { get; set; }
        public string Profile { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverPhotoSmall { get; set; }
        public List<string> ActivityTypes { get; set; }
        public string ActivityTypesIcon { get; set; }
        public List<string> Dimensions { get; set; }
        public string SportType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool Private { get; set; }
        public int MemberCount { get; set; }
        public bool Featured { get; set; }
        public bool Verified { get; set; }
        public string Url { get; set; }
        public string Membership { get; set; }
        public bool Admin { get; set; }
        public bool Owner { get; set; }
    }


}
