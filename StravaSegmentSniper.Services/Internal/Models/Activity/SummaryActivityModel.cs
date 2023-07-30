﻿using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Misc;

namespace StravaSegmentSniper.Services.Internal.Models.Activity
{
    public class SummaryActivityModel
    {

        public string ActivityId { get; set; }
        public int ResourceState { get; set; }
        public MetaAthleteModel Athlete { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public int MovingTime { get; set; }
        public int ElapsedTime { get; set; }
        public double TotalElevationGain { get; set; }
        public string Type { get; set; }
        public string SportType { get; set; }
        public int WorkoutType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public string Timezone { get; set; }
        public double UtcOffset { get; set; }
        public object LocationCity { get; set; }
        public object LocationState { get; set; }
        public string LocationCountry { get; set; }
        public int AchievementCount { get; set; }
        public int KudosCount { get; set; }
        public int CommentCount { get; set; }
        public int AthleteCount { get; set; }
        public int PhotoCount { get; set; }
        public PolylineMapModel Map { get; set; }
        public bool Trainer { get; set; }
        public bool Commute { get; set; }
        public bool Manual { get; set; }
        public bool Private { get; set; }
        public string Visibility { get; set; }
        public bool Flagged { get; set; }
        public string GearId { get; set; }
        public List<double> StartLatlng { get; set; }
        public List<double> EndLatlng { get; set; }
        public double AverageSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public double AverageWatts { get; set; }
        public double Kilojoules { get; set; }
        public bool DeviceWatts { get; set; }
        public bool HasHeartrate { get; set; }
        public double AverageHeartrate { get; set; }
        public double MaxHeartrate { get; set; }
        public bool HeartrateOptOut { get; set; }
        public bool DisplayHideHeartrateOption { get; set; }
        public double ElevHigh { get; set; }
        public double ElevLow { get; set; }
        public object UploadId { get; set; }
        public string UploadIdStr { get; set; }
        public string ExternalId { get; set; }
        public bool FromAcceptedTag { get; set; }
        public int PrCount { get; set; }
        public int TotalPhotoCount { get; set; }
        public bool HasKudoed { get; set; }
        public int? AverageTemp { get; set; }
        public int SufferScore { get; set; }
    }
}
